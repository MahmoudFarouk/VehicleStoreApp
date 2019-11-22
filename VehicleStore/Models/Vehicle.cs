using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleStore.Models
{
    public class Vehicle
    {
        public Vehicle() { }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(128)")]
        public string VIN { get; set; }

        [Column(TypeName = "nvarchar(128)")]
        public string RegNo { get; set; }
        public bool IsConnected { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}