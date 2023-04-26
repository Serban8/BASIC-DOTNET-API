using DataLayer.Enums;

namespace Core.Dtos
{
    public class GradeDto
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public string Course { get; set; }
        public DateTime Date { get; set; }
    }
}
