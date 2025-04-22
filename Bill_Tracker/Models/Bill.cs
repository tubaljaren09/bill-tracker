using System.ComponentModel.DataAnnotations.Schema;

namespace Bill_Tracker.Models
{
    [Table("Bills")]
    public class Bill
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("bill_name")]
        public string BillName { get; set; }

        [Column("amount")]
        public decimal Amount { get; set; }

        [Column("due_date")]
        public DateTime DueDate { get; set; }

        [Column("is_paid")]
        public bool IsPaid { get; set; }

        [Column("payment_date")]
        public DateTime? PaymentDate { get; set; }

        [Column("category")]
        public string Category { get; set; }
    }
}
