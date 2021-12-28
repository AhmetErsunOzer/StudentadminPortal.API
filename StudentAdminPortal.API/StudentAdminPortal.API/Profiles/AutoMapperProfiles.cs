using AutoMapper;
using StudentAdminPortal.API.DataModels;
using StudentAdminPortal.API.DomainModels;

namespace StudentAdminPortal.API.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Student, StudentDM>().ReverseMap();
            CreateMap<Gender, GenderDM>().ReverseMap();
            CreateMap<Adress, AdressDM>().ReverseMap();
        }
    }
}
