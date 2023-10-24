using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ForumLike
    {
        public int Id { get; set; }

        #region Relationship
        public int PostId { get; set; }
        public required ForumPost Post { get; set; }
        public int UserId { get; set; }
        public required User User { get; set; }
        #endregion
    }
}
