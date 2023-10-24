using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class UserStorie
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public bool Status { get; set; }

        #region Relationship
        public int UserId { get; set; }
        public required User User { get; set; }
        #endregion
    }
}
