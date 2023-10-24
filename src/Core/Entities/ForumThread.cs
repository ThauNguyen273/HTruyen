using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ForumThread
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public DateTime Created { get; set; }

        #region Relationship
        public int ForumId { get; set; }
        public required Forum Forum { get; set; }
        public int UserId { get; set; }
        public required User User { get; set; }
        #endregion
    }
}
