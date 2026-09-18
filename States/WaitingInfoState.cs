public class WaitingInfoState : IncidentState
{
    public override string Name => "ожидание информации";

    public override void ProvideInfo(Incident incident, string info)
    {
        incident.SetState(new InProgressState());
        Console.WriteLine($"пользователь ответил: {info}, заявка снова в работе");
    }

    public override void Escalate(Incident incident, string reason)
    {
        if (incident.Priority < 5)
        {
            incident.Priority++;
        }

        Console.WriteLine($"приоритет повышен до {incident.Priority}, причина: {reason}");
    }
}
