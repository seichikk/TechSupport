public class NewState : IncidentState
{
    public override string Name => "новая";

    public override void Assign(Incident incident, string executor)
    {
        incident.Assignee = executor;
        incident.SetState(new InProgressState());
        Console.WriteLine($"исполнитель {executor} назначен, заявка взята в работу");
    }

    public override void Reject(Incident incident, string reason)
    {
        incident.RejectReason = reason;
        incident.ClosedDate = DateTime.Now;
        incident.SetState(new ClosedState());
        Console.WriteLine($"заявка отклонена и закрыта, причина: {reason}");
    }

    public override void ChangePriority(Incident incident, int priority)
    {
        if (priority < 1 || priority > 5)
        {
            Console.WriteLine("приоритет должен быть от 1 до 5");
            return;
        }

        incident.Priority = priority;
        Console.WriteLine($"приоритет изменён на {priority}");
    }
}
