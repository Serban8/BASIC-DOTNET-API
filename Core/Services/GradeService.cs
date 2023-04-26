using Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class GradeService
    {
        private readonly DataLayer.UnitOfWork unitOfWork;

        public GradeService(DataLayer.UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<StudentWithGradesDto> GetAll()
        {
            var students = unitOfWork.Students.GetAllWithGrades();

            return students.Select(s => new StudentWithGradesDto
            {
                Id = s.Id,
                FullName = s.FirstName + " " + s.LastName,
                Grades = s.Grades.Select(g => new GradeDto
                {
                    Id = g.Id,
                    Course = g.Course.ToString(),
                    Value = g.Value,
                    Date = g.DateReceived
                }).ToList()
            }).ToList();
        }

        public StudentWithGradesDto GetByStudentId(int studentId) //TODO: this and the method above have duplicate code
        {
            var student = unitOfWork.Students.GetGradesById(studentId);

            return new StudentWithGradesDto
            {
                Id = student.Id,
                FullName = student.FirstName + " " + student.LastName,
                Grades = student.Grades.Select(g => new GradeDto
                {
                    Id = g.Id,
                    Course = g.Course.ToString(),
                    Value = g.Value,
                    Date = g.DateReceived
                }).ToList()
            };
        }
    }
}
