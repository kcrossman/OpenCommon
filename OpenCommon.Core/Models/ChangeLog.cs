using System;

namespace OpenCommon.Core.Models
{
    public class ChangeLog
    {
        public DateTime Time { get; set; }
        public Guid UserId { get; set; }
        public string Context { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public ChangeLogChange Change { get; set; }
    }
}
