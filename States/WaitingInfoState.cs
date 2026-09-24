public class WaitingInfoState : IncidentStateBase
{
    public override string Name => "ожидание информации";

    public override IncidentStateBase HandleProvideInfo(Incident incident, string info)
    {
        Console.WriteLine($"пользователь ответил: {info}, заявка снова в работе");
        return new InProgressState();
    }

    public override IncidentStateBase HandleEscalate(Incident incident, string reason)
    {
        if (incident.Priority >= 5)
        {
            Console.WriteLine("приоритет уже максимальный, повышать некуда");
            return this;
        }

        incident.Priority++;
        Console.WriteLine($"приоритет повышен до {incident.Priority}, причина: {reason}");
        return this;
    }
}
