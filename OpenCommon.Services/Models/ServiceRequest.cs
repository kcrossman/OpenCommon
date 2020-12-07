using System;
using System.Collections.Generic;
using OpenCommon.Services.Enumerations;

namespace OpenCommon.Services.Models
{
    public abstract class ServiceRequest
    {
        public Guid Id { get; } = Guid.NewGuid();
        public RequestType Type { get; }
        public string Source { get; }
        public Dictionary<string, dynamic> Parameters { get; }

        public ServiceRequest(RequestType requestType, string requestSource, Dictionary<string, dynamic> requestParameters)
        {
            Type = requestType;
            Source = requestSource;
            Source = requestSource;
            Parameters = requestParameters;
        }
    }
}
