namespace ForumMVC.Models
{
    public class CommentViewModel
    {
        public int Id { get; private set; }
        static int Instances = 1;

        public string? Body { get; set; }
        public int Likes { get; set; }
        public CommentViewModel()
        {
            Id = Instances;
            Likes = 0;
            Instances++;
        }
    }
}
