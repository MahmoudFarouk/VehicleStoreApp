using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleStore.Models
{
    public class Customer
    {
        public Customer()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int Id { get; set; }

        [Column(TypeName = "nvarchar(128)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string Address { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}