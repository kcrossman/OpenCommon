using System.Collections.Generic;
using OpenCommon.Services.Enumerations;
using OpenCommon.Services.Models;

namespace OpenCommon.Services.Restful.Models
{
    public class RestfulRequest : ServiceRequest
    {
        public RestfulRequest(RequestType requestType, string requestSource, Dictionary<string, dynamic> requestParameters) : base(requestType, requestSource, requestParameters)
        {
        }
    }
}
