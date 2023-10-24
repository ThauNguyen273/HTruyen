using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class UserSubscription
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        #region Relationship
        public int UserId { get; set; }
        public required User User { get; set; }
        public int PlanId { get; set; }
        public required UserPlan Plan { get; set; }
        #endregion
    }
}
