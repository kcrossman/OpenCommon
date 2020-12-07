using System;
using OpenCommon.Services.Enumerations;

namespace OpenCommon.Services.Models
{
    public abstract class ServiceResponse : ServiceReceipt
    {
        public dynamic Payload { get; }

        protected ServiceResponse(Guid requestId, ResponseCode responseCode, string responseMessage, dynamic payload) : base (requestId, responseCode, responseMessage)
        {
            Payload = payload;
        }
    }
}
