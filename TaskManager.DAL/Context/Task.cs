namespace TaskManager.DAL.Context;

public partial class Task
{
    public int TaskId { get; set; }
    public string TaskName { get; set; }
    public string TaskDescription { get; set; }
    public bool IsComplete { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
}
