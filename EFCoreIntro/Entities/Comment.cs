namespace EFCoreIntroduction.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public bool Recommend { get; set; }
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}