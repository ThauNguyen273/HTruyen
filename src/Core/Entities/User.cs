using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Email { get; set; }
        public required string Password { get; set; }
        public required string PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateTime Created { get; set; }

        #region Relationship
        public int RoleId { get; set; }
        public required Role Role { get; set; } 
        public int UserPlanId { get; set; }
        public UserPlan? UserPlan { get; set; }
        public int UserWalletId { get; set; }
        public required UserWallet UserWallet { get; set; }
        #endregion
    }
}
