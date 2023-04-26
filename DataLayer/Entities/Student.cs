namespace DataLayer.Entities;

public class Student : User
{
    public int ClassId { get; set; }
    public Class Class { get; set; }
    public List<Grade> Grades { get; set; }
}

