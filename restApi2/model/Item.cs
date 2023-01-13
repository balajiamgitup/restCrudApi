using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace restApi2.model
{
    public class Item
    {
        [KeyAttribute()]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ItemID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }


     //   public int OrderID { get; set; }
      //  public Order Order { get; set; }


    }
}
