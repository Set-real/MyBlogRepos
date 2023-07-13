namespace BlogApp.Model.DataModel
{
    /// <summary>
    /// Модель тега
    /// </summary>
    public class Teg
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Value { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        // Создаю привязку со статьей "многие ко многим"
        public List<Article> Articles { get; set; } = new List<Article>();
    }
}
