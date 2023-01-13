using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace restApi2.model
{
    public class OrderItems
    {
        [KeyAttribute()]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long OrderItemID { get; set; }
        public Nullable<long> OrderID { get; set; }
        public Nullable<int> ItemID { get; set; }
        public Nullable<int> Quantity { get; set; }
    }
}
