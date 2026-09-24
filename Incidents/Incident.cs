public class Incident
{
    public int Id { get; }
    public string Title { get; }
    public string Description { get; }
    public string Assignee { get; set; } = "";
    public string RejectReason { get; set; } = "";
    public DateTime? ResolvedDate { get; set; }
    public DateTime? ClosedDate { get; set; }
    public int Priority { get; set; }
    public IncidentStateBase State { get; private set; }
    private int DefaultPriority = 3;

    public Incident(int id, string title, string description)
    {
        Id = id;
        Title = title;
        Description = description;
        Priority = DefaultPriority;
        State = new NewState();
    }

    public void Assign(string executor)
    {
        State = State.HandleAssign(this, executor);
    }

    public void Reject(string reason)
    {
        State = State.HandleReject(this, reason);
    }

    public void ChangePriority(int priority)
    {
        State = State.HandleChangePriority(this, priority);
    }

    public void RequestInfo(string question)
    {
        State = State.HandleRequestInfo(this, question);
    }

    public void ProvideInfo(string info)
    {
        State = State.HandleProvideInfo(this, info);
    }

    public void Resolve(string resolution)
    {
        State = State.HandleResolve(this, resolution);
    }

    public void Close()
    {
        State = State.HandleClose(this);
    }

    public void Reopen(string reason)
    {
        State = State.HandleReopen(this, reason);
    }

    public void Escalate(string reason)
    {
        State = State.HandleEscalate(this, reason);
    }
}
