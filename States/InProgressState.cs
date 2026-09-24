public class InProgressState : IncidentStateBase
{
    public override string Name => "в работе";

    public override IncidentStateBase HandleAssign(Incident incident, string executor)
    {
        if (executor == incident.Assignee)
        {
            Console.WriteLine($"{executor} и так исполнитель этой заявки");
            return this;
        }

        Console.WriteLine($"исполнитель заменён: был {incident.Assignee}, теперь {executor}");
        incident.Assignee = executor;
        return this;
    }

    public override IncidentStateBase HandleRequestInfo(Incident incident, string question)
    {
        Console.WriteLine($"у пользователя запрошено: {question}");
        return new WaitingInfoState();
    }

    public override IncidentStateBase HandleResolve(Incident incident, string resolution)
    {
        incident.ResolvedDate = DateTime.Now;
        Console.WriteLine($"проблема решена: {resolution}");
        return new ResolvedState();
    }
}
