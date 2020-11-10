using System.Collections.Generic;

namespace OpenCommon.Core.Models
{
    public class ChangeLogChange
    {
        public string Before { get; set; }

        public string After { get; set; }

        private List<string> changes;
        public List<string> Changes {
            get => changes ?? (changes = new List<string>());
            set => changes = value;
        }
    }
}
