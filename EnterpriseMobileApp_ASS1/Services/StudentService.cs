
using EnterpriseMobileApp_ASS1.Dto;
using EnterpriseMobileApp_ASS1.DTO;
using EnterpriseMobileApp_ASS1.Models;
using EnterpriseMobileApp_ASS1.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMobileApp_ASS1.Services
{
    public class StudentService : IStudentService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _context;
        public StudentService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

       
        public async Task<bool>  SignUp(StudentRegisterDto registerDto)
        {
            if (await _context.Student.AnyAsync(t => t.Name == registerDto.Name))
            {
                throw new InvalidOperationException("Name Is already registered");
            }
            
            
                var newTourist = new Student
                {
                    Name = registerDto.Name,
                    StudentId = registerDto.StudentId,
                    Level = registerDto.Level,
                    Gender = registerDto.Gender,
                    Password = registerDto.Password,
                    Email = registerDto.Email,
                    Image = "Default/default.jpg"
                };
                
                _context.Student.Add(newTourist);
                await _context.SaveChangesAsync();

            return true;
        }

       
    
        public async Task<bool> SignIn(StudentLoginDto loginDto)
    {

            if (!await _context.Student.AnyAsync(t => t.Name == loginDto.Name&& t.Password==loginDto.password))
                throw new InvalidOperationException("there is no user  with  this Name");

            return true;
        }

        public async Task<string> UpdateUserInfo(string Name ,StudentInfoDto infoDto)
        {
            // Retrieve the student entity from the database
            var student = await _context.Student.FirstOrDefaultAsync(s => s.Name==Name);

            // If student doesn't exist, return 404 Not Found
            if (student == null)
            {
                return ("Student not found.");
            }

            // Update the student's properties if they are provided in the DTO
            if (!string.IsNullOrEmpty(infoDto.Name))
            {
                student.Name = infoDto.Name;
            }

            if (!string.IsNullOrEmpty(infoDto.Email))
            {
                student.Email = infoDto.Email;
            }

            if (!string.IsNullOrEmpty(infoDto.Gender))
            {
                student.Gender = infoDto.Gender;
            }

            if (infoDto.Level != null)
            {
                student.Level = infoDto.Level;
            }

            if (!string.IsNullOrEmpty(infoDto.Image))
            {
                student.Image = infoDto.Image;
            }

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return a message indicating success
            return ("Update done.");
        }


        public StudentInfoDto GetStudentInfo(string studentname)
        {
            var student = _context.Student.FirstOrDefault(s => s.Name == studentname);

            if (student == null)
            {
                return null; // Or throw an exception as per your requirement
            }

            var baseUrl = GetBaseUrl();
            var imageUrl = $"{baseUrl}/{student.Image}";

            var studentInfo = new StudentInfoDto
            {
                Name = student.Name,
                StudentId = student.StudentId,
                Gender = student.Gender,
                Email = student.Email,
                Level = student.Level,
                Image = imageUrl
            };

            return studentInfo;
        }

        public string GetBaseUrl()
        {
            var request = _httpContextAccessor.HttpContext.Request;
            return $"{request.Scheme}://{request.Host}";
        }

       
    }
}


