using System;
using OpenCommon.Services.Enumerations;

namespace OpenCommon.Services.Models
{
    public abstract class ServiceReceipt
    {
        public Guid RequestId { get; }

        public ResponseCode Code { get; }

        public string Message { get; }

        protected ServiceReceipt(Guid requestId, ResponseCode responseCode, string message)
        {
            RequestId = requestId;
            Code = responseCode;
            Message = message;
        }
    }
}
