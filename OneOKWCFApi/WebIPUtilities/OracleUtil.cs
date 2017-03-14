using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

using Oracle.DataAccess.Client;

namespace OneOKWCFApi.WebIPUtilities {
  public class OracleUtil {

    // public methods...
    /// <summary>
    /// Bulk insert using arrayBindCount for using arrays as Oracle parameters
    /// </summary>
    /// <param name="envAndPipe"></param>
    /// <param name="cmdText"></param>
    /// <param name="oracleParams"></param>
    /// <param name="cmdType"></param>
    /// <param name="arrayBindCount"></param>
    public static void ExecuteOracleBatchAction(string envAndPipe, string cmdText, OracleParameter[] oracleParams, CommandType cmdType, int arrayBindCount) {
      using (var conn = new OracleConnection(ConfigurationManager.ConnectionStrings[envAndPipe].ConnectionString)) {
        try {
          using (var cmd = new OracleCommand(cmdText, conn)) {
            cmd.CommandType = cmdType;
            cmd.Parameters.AddRange(oracleParams);
            conn.Open();
            cmd.BindByName = true;
            cmd.ArrayBindCount = arrayBindCount;
            cmd.ExecuteNonQuery();
          }
        } catch (Exception ex) {
          LogHandler.LogError("TFerc549DXmlFillPDF", ex);
        }
      }
    }
    /// <summary>
    /// Executes Oracle Reader and returns a DataTable object
    /// </summary>
    public static DataTable ExecuteOracleReader(string envAndPipe, string cmdText, OracleParameter[] oracleParams, CommandType cmdType) {

      var dt = new DataTable();
      using (var conn = new OracleConnection(ConfigurationManager.ConnectionStrings[envAndPipe].ConnectionString)) {
        using (var cmd = new OracleCommand(cmdText, conn)) {
          cmd.CommandType = cmdType;
          cmd.Parameters.AddRange(oracleParams);

          var da = new OracleDataAdapter(cmd);

          conn.Open();
          da.Fill(dt);
        }
      }
      return dt;
    }
  }
}