using StudentAdminPortal.API.DataModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAdminPortal.API.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudentsAsync();
        Task<Student> GetStudentAsync(Guid studentid);
        Task<List<Gender>> GetGendersAsync();
        Task<bool>Exists(Guid studentId);
        Task<Student> UpdateStudent(Guid studentId, Student request);
        Task<Student> DeleteStudentAsync(Guid studentId);
        Task<Student> AddStudentAsync(Student request);
        Task<bool> UpdateProfileImage(Guid studentId, string profileImageUrl);
    }
}
