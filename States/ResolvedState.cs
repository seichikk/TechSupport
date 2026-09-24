public class ResolvedState : IncidentStateBase
{
    public override string Name => "решена";

    public override IncidentStateBase HandleClose(Incident incident)
    {
        incident.ClosedDate = DateTime.Now;
        Console.WriteLine("заявка закрыта");
        return new ClosedState();
    }

    public override IncidentStateBase HandleReopen(Incident incident, string reason)
    {
        incident.ResolvedDate = null;
        Console.WriteLine($"заявка открыта заново, причина: {reason}");
        return new InProgressState();
    }
}
