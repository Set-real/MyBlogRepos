using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Contracts.Models.Comments
{
    public class GetCommentResponse
    {
        public int CommentAmount { get; set; }
        public CommentView[] commentView { get; set; }
    }
    public class CommentView
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
