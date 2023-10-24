using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ForumPost
    {
        public int Id { get; set; }
        public required string Content { get; set; }
        public DateTime Created { get; set; }

        #region Relationship
        public int ThreadId { get; set; }
        public required ForumThread Thread { get; set; }
        public int UserId { get; set; }
        public required User User { get; set; }
        #endregion
    }
}
