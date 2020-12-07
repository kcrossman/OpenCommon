using System.Collections.Generic;

namespace OpenCommon.Core.Models
{
    public class ChangeLogChange
    {
        public string Before { get; set; }

        public string After { get; set; }

        private List<string> _changes;
        public List<string> Changes {
            get => _changes ??= new List<string>();
            set => _changes = value;
        }
    }
}
