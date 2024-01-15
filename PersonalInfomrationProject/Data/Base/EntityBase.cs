using System;
using System.ComponentModel.DataAnnotations;

namespace PersonalInfomrationProject.Data.Base
{
    public abstract class EntityBase
    {
        [Key]
        public string Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
