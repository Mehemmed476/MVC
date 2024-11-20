using MVCtask1.Models;

namespace MVCtask1.Data;

public class DataStore
{
    public static List<Student> Students { get; set; } = new List<Student>();
    public static List<Group> Groups { get; set; } = new List<Group>();
    public static List<Teacher> Teachers { get; set; } = new List<Teacher>(); 
}