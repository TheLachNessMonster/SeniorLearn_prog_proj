using System.ComponentModel.DataAnnotations;

namespace SeniorLearn.Data;

public class Lesson
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Location { get; set; }
    public int Capacity { get; set; }
    public Member Instructor { get; set; }
    public List<Member> EnrolledMembers { get; set; }

    public Status Status { get; set; }
}

public enum Status { DRAFT = 1, SCHEDULED = 2, CLOSED = 3, COMPLETE = 4, CANCELLED = 5 }

