namespace BlogApp.Contracts.Models.Tegs
{
    public class GetTegRequest
    {
        public int TegAmount { get; set; }
        public TegView TegView { get; set; }
    }
    public class TegView
    {
        public string Value { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
