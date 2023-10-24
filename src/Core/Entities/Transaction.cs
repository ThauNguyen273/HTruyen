using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public required string TransactionType { get; set; }
        public double Amount { get; set; }
        public DateTime Created { get; set; }

        #region Relationship
        public int UserId { get; set; }
        public required User User { get; set; }
        #endregion
    }
}
