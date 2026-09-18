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
    public IncidentState State { get; private set; }
    private int DefaultPriority = 3;

    public Incident(int id, string title, string description)
    {
        Id = id;
        Title = title;
        Description = description;
        Priority = DefaultPriority;
        State = new NewState();
    }

    public void SetState(IncidentState state)
    {
        State = state;
    }

    public void Assign(string executor)
    {
        State.Assign(this, executor);
    }

    public void Reject(string reason)
    {
        State.Reject(this, reason);
    }

    public void ChangePriority(int priority)
    {
        State.ChangePriority(this, priority);
    }

    public void RequestInfo(string question)
    {
        State.RequestInfo(this, question);
    }

    public void ProvideInfo(string info)
    {
        State.ProvideInfo(this, info);
    }

    public void Resolve(string resolution)
    {
        State.Resolve(this, resolution);
    }

    public void Close()
    {
        State.Close(this);
    }

    public void Reopen(string reason)
    {
        State.Reopen(this, reason);
    }

    public void Escalate(string reason)
    {
        State.Escalate(this, reason);
    }
}
