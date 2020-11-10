using System;

namespace OpenCommon.Services.Restful.Models
{
    public abstract class Request
    {
        private Guid RequestId { get; set; } = Guid.NewGuid();
        public string RequestSource { get; set; }
    }
}
