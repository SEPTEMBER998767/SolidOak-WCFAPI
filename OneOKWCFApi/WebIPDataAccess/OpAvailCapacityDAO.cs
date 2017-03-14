using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using Oracle.DataAccess.Client;
using System.Data.SqlClient;
using System.Net;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using System.ServiceModel.Web;

using OneOKWCFApi.WebIPUtilities;

namespace OneOKWCFApi.WebIPDataAccess {
  public class OpAvailCapacityDAO {

    /// <summary>
    /// This Method gets Operationally Available Capacity data in a Dataset.
    /// </summary>
    /// <param name="startDate">Starting Date</param>
    /// <param name="envAndPipe">TSP Number</param>
    /// <returns>DataSet</returns>
    /// <exception cref="OracleException">Condition.</exception>
    /// <exception cref="InvalidOperationException">Condition.</exception>
    /// <exception cref="ArgumentException">The value was not a valid <see cref="T:System.Data.CommandType" />. </exception>
    public static DataTable GetOperationallyAvailableData(string envAndPipe, DateTime startDateValue, DateTime endDateValue) {


      //  Check that the difference between start and end dates is less than 3 years (1096 days)
      //  The website restricts users' date selection.  But if a hacker finds a way to bypass the restriction,
      //  then return an empty table without throwing any exceptions.
      if (((endDateValue - startDateValue).Days > 1096) || (startDateValue > endDateValue)) {
        return new DataTable();
      }

      // append end of day hour, minute, and second to the end date value
      string modifiedEndDate = string.Format("{0:MM/dd/yyyy}", endDateValue) + " 23:59:59";
      endDateValue = Convert.ToDateTime(modifiedEndDate);

      string procName = "CNSS.WEBIP_CAPACITY.GET_OPERAVAIL_BYDATES";

      var oracleParams = new OracleParameter[3];
      oracleParams[0] = new OracleParameter("StartDate", OracleDbType.Date, ParameterDirection.Input) {
        Value = startDateValue
      };
      oracleParams[1] = new OracleParameter("EndDate", OracleDbType.Date, ParameterDirection.Input) {
        Value = endDateValue
      };

      oracleParams[2] = new OracleParameter("io_cursor", OracleDbType.RefCursor, ParameterDirection.Output);

      var dt = OracleUtil.ExecuteOracleReader(envAndPipe, procName, oracleParams, CommandType.StoredProcedure);
      return dt;
    }
  }
}