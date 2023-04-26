using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class StudentWithGradesDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<GradeDto> Grades { get; set; }
    }
}
