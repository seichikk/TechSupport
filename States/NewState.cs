public class NewState : IncidentStateBase
{
    public override string Name => "новая";

    public override IncidentStateBase HandleAssign(Incident incident, string executor)
    {
        incident.Assignee = executor;
        Console.WriteLine($"исполнитель {executor} назначен, заявка взята в работу");
        return new InProgressState();
    }

    public override IncidentStateBase HandleReject(Incident incident, string reason)
    {
        incident.RejectReason = reason;
        incident.ClosedDate = DateTime.Now;
        Console.WriteLine($"заявка отклонена и закрыта, причина: {reason}");
        return new ClosedState();
    }

    public override IncidentStateBase HandleChangePriority(Incident incident, int priority)
    {
        if (priority < 1 || priority > 5)
        {
            Console.WriteLine("приоритет должен быть от 1 до 5");
            return this;
        }

        if (priority == incident.Priority)
        {
            Console.WriteLine($"приоритет и так равен {priority}");
            return this;
        }

        incident.Priority = priority;
        Console.WriteLine($"приоритет изменён на {priority}");
        return this;
    }
}
