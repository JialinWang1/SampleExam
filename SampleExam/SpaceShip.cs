using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace SampleExam
{
    public class SpaceShip
    {
        [Key]
        public long ShipID { get; set; }
        public int MaxCapacity { get; set; }
        //public string Planet { get; set; }
        public int Utilization { get; set; }
        public Planet Planet { get; set; }
    }
}