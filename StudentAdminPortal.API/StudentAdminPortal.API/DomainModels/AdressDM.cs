using System;

namespace StudentAdminPortal.API.DomainModels
{
    public class AdressDM
    {
        public Guid Id { get; set; }
        public string PysicalAdress { get; set; }
        public string PostalAdress { get; set; }

        //Navigation Property
        public Guid StudentId { get; set; }
    }
}
