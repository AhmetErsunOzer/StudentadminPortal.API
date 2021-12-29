using AutoMapper;
using StudentAdminPortal.API.DataModels;
using StudentAdminPortal.API.DomainModels;
using System;

namespace StudentAdminPortal.API.Profiles.AfterMaps
{
    public class AddStudentRequestAfterMap : IMappingAction<AddStudentRequest, Student>
    {
        public void Process(AddStudentRequest source, Student destination, ResolutionContext context)
        {
            destination.Id = Guid.NewGuid();
            destination.Adress = new Adress()
            {
                Id = Guid.NewGuid(),
                PysicalAdress = source.PysicalAdress,
                PostalAdress = source.PostalAdress
            };        
        }
    }
}
