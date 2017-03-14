using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.ServiceModel.Web;

using OneOKWCFApi.WebIPBusiness;

namespace OneOKWCFApi {
  [JavascriptCallbackBehavior(UrlParameterName = "$getOpAvailDataClientFunction")]
  public class WebIPRestServices : IWebIPRestServices {

    //"DEV_vgt", DateTime.Parse("02/02/2016"), DateTime.Parse("02/03/2016")
    public Stream GetOperationallyAvailableData(string envAndPipe, string startDate, string endDate, string callbackFunctionName) {
      OperationallyAvailable opAv = new OperationallyAvailable();
      return opAv.GetData(envAndPipe, DateTime.Parse(startDate), DateTime.Parse(endDate), callbackFunctionName);
    }
  }
}
