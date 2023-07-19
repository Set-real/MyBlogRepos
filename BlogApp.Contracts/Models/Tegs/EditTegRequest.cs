namespace BlogApp.Contracts.Models.Tegs
{
    public class EditTegRequest
    {
        public Guid Id { get; set; }
        public string NewValue { get; set; }
    }
}
