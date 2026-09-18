public class InProgressState : IncidentState
{
    public override string Name => "в работе";

    public override void Assign(Incident incident, string executor)
    {
        Console.WriteLine($"исполнитель заменён: был {incident.Assignee}, теперь {executor}");
        incident.Assignee = executor;
    }

    public override void RequestInfo(Incident incident, string question)
    {
        incident.SetState(new WaitingInfoState());
        Console.WriteLine($"у пользователя запрошено: {question}");
    }

    public override void Resolve(Incident incident, string resolution)
    {
        incident.ResolvedDate = DateTime.Now;
        incident.SetState(new ResolvedState());
        Console.WriteLine($"проблема решена: {resolution}");
    }
}
