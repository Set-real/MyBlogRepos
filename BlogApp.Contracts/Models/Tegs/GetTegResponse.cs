namespace BlogApp.Contracts.Models.Tegs
{
    public class GetTegResponse
    {
        public int TegAmount { get; set; }
        public TegView TegView { get; set; }
    }
    public class TegView
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
