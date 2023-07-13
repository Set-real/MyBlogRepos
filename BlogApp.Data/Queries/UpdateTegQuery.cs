namespace BlogApp.Data.Queries
{
    /// <summary>
    /// Класс для обновления тега
    /// </summary>
    public class UpdateTegQuery
    {
        public string NewTeg { get; }

        public UpdateTegQuery(string newTeg)
        {
            NewTeg = newTeg;
        }
    }
}
