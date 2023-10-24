using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class UserPlan
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public double Price { get; set; }
        public required string Privilege { get; set; }

        #region Relationship
        #endregion
    }
}
