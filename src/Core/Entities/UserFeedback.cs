using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class UserFeedback
    {
        public int Id { get; set; }
        public required string Subject { get; set; }
        public required string Content { get; set; }
        public bool Status { get; set; }

        #region Relationship
        public int UserId { get; set; }
        public required User User { get; set; }
        #endregion
    }
}
