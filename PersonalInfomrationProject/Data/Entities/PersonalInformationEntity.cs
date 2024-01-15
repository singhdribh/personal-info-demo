using PersonalInfomrationProject.Data.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalInfomrationProject.Data.Entities
{
    [Table("PersonalInformationTbl")]
    public class PersonalInformationEntity : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Language { get; set; }
        public DateTimeOffset Dob { get; set; }
    }
}
