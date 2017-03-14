using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace OneOKWCFApi.WebIPBusiness {
  public interface IOperationallyAvailable {
    Stream GetData(string envAndPipe, DateTime startDate, DateTime endDate, string callbackFunctionName);
  }
}
