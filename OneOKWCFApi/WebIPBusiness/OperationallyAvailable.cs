using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

using OneOKWCFApi.WebIPDataAccess;

namespace OneOKWCFApi.WebIPBusiness {
  public class OperationallyAvailable : IOperationallyAvailable {
    public Stream GetData(string envAndPipe, DateTime startDate, DateTime endDate, string callbackFunctionName) {
      return DAOUtil.ConvertDataTabletoString(OpAvailCapacityDAO.GetOperationallyAvailableData(envAndPipe, startDate, endDate), callbackFunctionName);
    }
  }
}