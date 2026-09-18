public class Program
{
    static void Main()
    {
        Incident incident = new Incident(1, "не печатает принтер", "принтер на третьем этаже не реагирует на задания");

        incident.Resolve("перезагрузили принтер");
        incident.ChangePriority(4);
        incident.Assign("Петров");
        incident.ChangePriority(5);
        incident.Assign("Сидоров");
        incident.RequestInfo("какая модель принтера?");
        incident.Resolve("обновили драйвер");
        incident.Escalate("пользователь не отвечает два дня");
        incident.ProvideInfo("HP LaserJet 1020");
        incident.Resolve("обновили драйвер");
        incident.Reopen("принтер снова не печатает");
        incident.Resolve("заменили картридж");
        incident.Close();
        incident.Assign("Иванов");

        Console.WriteLine();

        Incident secondIncident = new Incident(2, "не печатает принтер", "то же самое, что в заявке 1");

        secondIncident.Reject("дубликат заявки 1");
        secondIncident.Assign("Петров");
    }
}
