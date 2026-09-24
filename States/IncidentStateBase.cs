public abstract class IncidentStateBase
{
    public abstract string Name { get; }

    public virtual IncidentStateBase HandleAssign(Incident incident, string executor)
    {
        PrintNotAllowed("назначить исполнителя");
        return this;
    }

    public virtual IncidentStateBase HandleReject(Incident incident, string reason)
    {
        PrintNotAllowed("отклонить заявку");
        return this;
    }

    public virtual IncidentStateBase HandleChangePriority(Incident incident, int priority)
    {
        PrintNotAllowed("изменить приоритет");
        return this;
    }

    public virtual IncidentStateBase HandleRequestInfo(Incident incident, string question)
    {
        PrintNotAllowed("запросить информацию");
        return this;
    }

    public virtual IncidentStateBase HandleProvideInfo(Incident incident, string info)
    {
        PrintNotAllowed("принять ответ пользователя");
        return this;
    }

    public virtual IncidentStateBase HandleResolve(Incident incident, string resolution)
    {
        PrintNotAllowed("решить заявку");
        return this;
    }

    public virtual IncidentStateBase HandleClose(Incident incident)
    {
        PrintNotAllowed("закрыть заявку");
        return this;
    }

    public virtual IncidentStateBase HandleReopen(Incident incident, string reason)
    {
        PrintNotAllowed("открыть заявку заново");
        return this;
    }

    public virtual IncidentStateBase HandleEscalate(Incident incident, string reason)
    {
        PrintNotAllowed("эскалировать заявку");
        return this;
    }

    protected void PrintNotAllowed(string action)
    {
        Console.WriteLine($"нельзя {action} в статусе «{Name}»");
    }
}
