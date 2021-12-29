using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.API.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdminPortal.API.Repositories
{
    public class SqlStudentRepository : IStudentRepository
    {
        private readonly StudentAdminContext _context;

        public SqlStudentRepository(StudentAdminContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _context.Students.Include(nameof(Gender)).Include(nameof(Adress)).ToListAsync();
        }
        public async Task<Student> GetStudentAsync(Guid studentid)
        {
            return await _context.Students
                .Include(nameof(Gender)).Include(nameof(Adress))
                .FirstOrDefaultAsync(x => x.Id == studentid);
        }

        public async Task<List<Gender>> GetGendersAsync()
        {
           return await _context.Gender.ToListAsync();
        }

        public Task<bool> Exists(Guid studentId)
        {
            return _context.Students.AnyAsync(x => x.Id == studentId);
        }

        public async Task<Student> UpdateStudent(Guid studentId, Student request)
        {
            var existingStudent=await GetStudentAsync(studentId);
            if (existingStudent != null)
            {
                existingStudent.FirstName = request.FirstName;
                existingStudent.LastName = request.LastName;
                existingStudent.DateOfBirth = request.DateOfBirth;
                existingStudent.Email = request.Email;
                existingStudent.Mobile = request.Mobile;
                existingStudent.GenderId = request.GenderId;
                existingStudent.Adress.PysicalAdress = request.Adress.PysicalAdress;
                existingStudent.Adress.PostalAdress = request.Adress.PostalAdress;

                await _context.SaveChangesAsync();
                return existingStudent;
            }
            return null;
        }

        public async Task<Student> DeleteStudentAsync(Guid studentId)
        {
            var student = await GetStudentAsync(studentId);
            if (student!=null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
            return null;
        }

        public async Task<Student> AddStudentAsync(Student request)
        {
            var student= await _context.Students.AddAsync(request);
            await _context.SaveChangesAsync();
            return student.Entity;
        }
    }
}
