public abstract class IncidentState
{
    public abstract string Name { get; }

    public virtual void Assign(Incident incident, string executor)
    {
        Deny("назначить исполнителя");
    }

    public virtual void Reject(Incident incident, string reason)
    {
        Deny("отклонить заявку");
    }

    public virtual void ChangePriority(Incident incident, int priority)
    {
        Deny("изменить приоритет");
    }

    public virtual void RequestInfo(Incident incident, string question)
    {
        Deny("запросить информацию");
    }

    public virtual void ProvideInfo(Incident incident, string info)
    {
        Deny("принять ответ пользователя");
    }

    public virtual void Resolve(Incident incident, string resolution)
    {
        Deny("решить заявку");
    }

    public virtual void Close(Incident incident)
    {
        Deny("закрыть заявку");
    }

    public virtual void Reopen(Incident incident, string reason)
    {
        Deny("открыть заявку заново");
    }

    public virtual void Escalate(Incident incident, string reason)
    {
        Deny("эскалировать заявку");
    }

    protected void Deny(string action)
    {
        Console.WriteLine($"нельзя {action} в статусе «{Name}»");
    }
}
