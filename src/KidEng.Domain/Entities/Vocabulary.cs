using KidEng.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace KidEng.Domain.Entities
{
    public class Vocabulary: EntityBase
    {
        [MaxLength(20)]
        public string Word { get; set; }
        [MaxLength(10)]
        public string Type { get; set; }
        [MaxLength(800)]
        public string Definition { get; set; }
        [MaxLength(800)]
        public string Example { get; set; }
    }
}
