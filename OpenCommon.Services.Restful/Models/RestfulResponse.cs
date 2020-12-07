using System;
using OpenCommon.Services.Enumerations;
using OpenCommon.Services.Models;

namespace OpenCommon.Services.Restful.Models
{
    public class RestfulResponse : ServiceResponse
    {
        public RestfulResponse(Guid requestId, ResponseCode responseCode, string responseMessage, string payload) : base(requestId, responseCode, responseMessage, payload)
        {
        }
    }
}
