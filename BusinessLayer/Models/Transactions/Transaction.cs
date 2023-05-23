using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models.Transactions
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public string TransactionType { get; set; }
        public string Status { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime TransactionDate { get; set; }
        public int FromAccountId { get; set; }
        public int ToAccountId { get; set; }
        public decimal CurrentBalance { get; set; }
    }
}
