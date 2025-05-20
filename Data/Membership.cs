namespace SeniorLearn.Data;

public class Membership
{
    public int Id { get; set; }
    public Member Member { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime RenewalDate { get; set; }
    public bool Paid { get; set; }
}
