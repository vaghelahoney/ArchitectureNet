using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuiteRx.Interface.Domain.Entities
{
    [Table("Clothes")]
    public class Clothes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("category")]
        public string Category { get; set; }

        [Column("stock_quantity")]
        public int StockQuantity { get; set; }

        [Column("is_available")]
        public bool IsAvailable { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

    }
}
