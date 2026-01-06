namespace ef.core.demo.ManyToMany;

public class Course
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public List<Student> Students { get; set; } = new();
}

public class Student
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public List<Course> Courses { get; set; } = new();
}
