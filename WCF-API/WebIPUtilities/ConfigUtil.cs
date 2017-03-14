using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;

namespace OneOKWCFApi.WebIPUtilities {
  public class ConfigUtil {
    public static string LogDirectory = ConfigurationManager.AppSettings["LogDirectory"];
  }
}