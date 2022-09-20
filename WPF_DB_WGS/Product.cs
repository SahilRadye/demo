using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WPF_DB_WGS
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }

        [Column("ProductName", TypeName = "varchar")]
        [MaxLength(20)]
        [Required]
        public string ProductName { get; set; }

        public DateTime? MfgDate { get; set; }

        public decimal? Price { get; set; }
    }
}
