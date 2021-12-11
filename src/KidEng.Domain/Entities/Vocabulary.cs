using KidEng.Domain.Common;

namespace KidEng.Domain.Entities
{
    public class Vocabulary: EntityBase
    {
        public string Word { get; set; }
        public string Type { get; set; }
        public string Definition { get; set; }
        public string Example { get; set; }
    }
}
