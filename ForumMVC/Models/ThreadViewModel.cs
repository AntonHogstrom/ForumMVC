namespace ForumMVC.Models
{
    public class ThreadViewModel
    {
        public int Id { get; private set; }
        static int Instances = 1;

        public string? Body { get; set; }
        public int Likes { get; set; }
        public ICollection<CommentViewModel> Comments { get; set; }

        public ThreadViewModel()
        {
            Id = Instances;
            Likes = 0;
            Comments = new List<CommentViewModel>();
            Instances++;
        }
    }
}
