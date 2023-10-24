using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class UserFavorite
    {
        public int Id { get; set; }

        #region Relationship
        public int UserId { get; set; }
        public required User User { get; set; }
        public int NovelId { get; set; }
        public required Novel Novel { get; set; }
        #endregion
    }
}
