using System;

namespace StudentAdminPortal.API.DomainModels
{
    public class StudentDM
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public long Mobile { get; set; }
        public string ProfileImageUrll { get; set; }
        public Guid GenderId { get; set; }

        //Navigation Properties
        public GenderDM Gender { get; set; }
        public AdressDM Adress { get; set; }
    }
}
