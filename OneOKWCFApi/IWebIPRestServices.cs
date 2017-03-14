using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;

namespace OneOKWCFApi {

  [ServiceContract]
  public interface IWebIPRestServices {

    [OperationContract]
    [WebInvoke(
      Method = "GET",  
      ResponseFormat = WebMessageFormat.Json,
      RequestFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.WrappedRequest,
      UriTemplate = "GetOpAvailCapacityData/{envAndPipe}/{startDate}/{endDate}&callback={callbackFunctionName}")]
    Stream GetOperationallyAvailableData(string envAndPipe, string startDate, string endDate, string callbackFunctionName);

  }
}
