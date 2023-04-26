using DataLayer;
using DataLayer.Entities;
using Core.Dtos;

namespace Core.Services
{
    public class UserService
    {
        private readonly UnitOfWork unitOfWork;
        private AuthorizationService authService { get; set; }

        public UserService(UnitOfWork unitOfWork, AuthorizationService authService)
        {
            this.unitOfWork = unitOfWork;
            this.authService = authService;
        }

        public RegisterDto RegisterStudent(RegisterDto payload)
        {
            if (payload == null) return null;
            
            var hashedPassword = authService.HashPassword(payload.Password);

            var newStudent = new Student
            {
                FirstName = payload.FirstName,
                LastName = payload.LastName,
                DateOfBirth = payload.DateOfBirth,
                ClassId = payload.ClassId,
                Address = payload.Address,
                Email = payload.Email,
                PasswordHash = hashedPassword
            };

            unitOfWork.Students.Insert(newStudent);
            unitOfWork.SaveChanges();

            return payload;
        }

        public RegisterDto RegisterTeacher(RegisterDto payload)
        {
            if (payload == null) return null;

            var hashedPassword = authService.HashPassword(payload.Password);
            
            var newTeacher = new Teacher
            {
                FirstName = payload.FirstName,
                LastName = payload.LastName,
                DateOfBirth = payload.DateOfBirth,
                Address = payload.Address,
                Email = payload.Email,
                PasswordHash = hashedPassword
            };

            unitOfWork.Teachers.Insert(newTeacher);
            unitOfWork.SaveChanges();

            return payload;
        }
        
        public string Validate(LoginDto payload)
        {
            User user = unitOfWork.Students.GetByEmail(payload.Email);

            if (user == null)
            {
                user = unitOfWork.Teachers.GetByEmail(payload.Email);
            }

            var passwordFine = authService.VerifyHashedPassword(user.PasswordHash, payload.Password);

            if (passwordFine)
            {
                return authService.GetToken(user);
            }
            else
            {
                return null;
            }

        }
    }
}
