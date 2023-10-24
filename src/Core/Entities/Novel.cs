using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Novel
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Author { get; set; }
        public bool Status { get; set; }
        public string? Thumbnail { get; set; }
        public int ViewCount { get; set; }

        #region Relationship
        public int CategoryId { get; set; }
        public required Category Category { get; set; }
        #endregion

    }
}
