using System;
using System.ComponentModel.DataAnnotations;

namespace KidEng.Domain.Common
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
