using System;

namespace OpenCommon.AutoRegistration.Models
{
    public class DependencyMapping
    {
        public Type AttributeType { get; set; }
        public Type ServiceType { get; set; }
        public Type ImplementationType { get; set; }
        public string Key { get; set; }
    }
}
