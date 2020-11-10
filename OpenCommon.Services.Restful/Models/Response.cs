using System;

namespace OpenCommon.Services.Restful.Models
{
    public abstract class Response
    {
        public Guid RequestId { get; set; }
    }
}
