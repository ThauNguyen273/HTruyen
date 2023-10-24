using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class StoryChapter
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public DateTime Created { get; set; }

        #region Relationship
        public int StoryId { get; set; }
        public required UserStorie Story { get; set; }
        #endregion
    }
}
