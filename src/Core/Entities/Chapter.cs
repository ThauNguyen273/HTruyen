using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Chapter
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public DateTime Created { get; set; }

        #region Relationship
        public int NovelId { get; set; }
        public required Novel Novel { get; set; }
        #endregion
    }
}
