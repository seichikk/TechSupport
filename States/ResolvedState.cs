public class ResolvedState : IncidentState
{
    public override string Name => "решена";

    public override void Close(Incident incident)
    {
        incident.ClosedDate = DateTime.Now;
        incident.SetState(new ClosedState());
        Console.WriteLine("заявка закрыта");
    }

    public override void Reopen(Incident incident, string reason)
    {
        incident.ResolvedDate = null;
        incident.SetState(new InProgressState());
        Console.WriteLine($"заявка открыта заново, причина: {reason}");
    }
}
