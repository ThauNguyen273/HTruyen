using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Ratings
    {
        public int Id { get; set; }
        public int Rating { get; set; }

        #region Relationship
        public int UserId { get; set; }
        public required User User { get; set; }
        public int NovelId { get; set; }
        public required Novel Novel { get; set; }
        #endregion
    }
}
