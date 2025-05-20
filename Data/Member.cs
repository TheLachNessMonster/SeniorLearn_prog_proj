namespace SeniorLearn.Data;

public class Member
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public List<Lesson> Enrollments { get; set; }
    public Roles Role { get; set; }
    public Membership Membership { get; set; }
}


public enum Roles { STANDARD = 1, PROFESSIONAL = 2 , HONORARY = 3}
