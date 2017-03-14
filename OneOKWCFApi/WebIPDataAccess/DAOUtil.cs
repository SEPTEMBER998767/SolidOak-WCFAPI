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

using Newtonsoft.Json;
using OneOKWCFApi.WebIPUtilities;

namespace OneOKWCFApi.WebIPDataAccess {
  /// summary>
  /// Functions that Fetch data from the database
  /// </summary>
  public class DAOUtil {

    public static Stream ConvertDataTabletoString(DataTable table, string callbackFunctionName) {


      //string s = "{\"data\": [{\"name\" : \"Tim Tosh\", \"age\" : \"48\", \"birthdate\" : \"06-23-1967\"},{\"name\" : \"Trace McGuire\", \"age\" : \"45\", \"birthdate\" : \"04-21-1970\"}]}";


      //string jsonData = callbackFunctionName + "(" + s + ")";
      //string jsonData = callbackFunctionName + "({\"data\" :" + JsonConvert.SerializeObject(table) + "})";
      string jsonData = callbackFunctionName + "(" + JsonConvert.SerializeObject(table) + ")";
      //string jsonData = JsonConvert.SerializeObject(table);
      WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
      return new MemoryStream(Encoding.UTF8.GetBytes(jsonData));
    }   
  }
}


