namespace LearnerRater.Tests.Contexts
{
    public class Resource : Review
    {
        public string Category { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public string Link { get; set; }
    }
}
