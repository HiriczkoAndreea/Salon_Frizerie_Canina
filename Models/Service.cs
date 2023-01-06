using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Salon_Frizerie_Canina.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
    
    }
}