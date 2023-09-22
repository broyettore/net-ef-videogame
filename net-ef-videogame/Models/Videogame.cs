using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame.Classes
{
    [Table("videogame")]
    public class Videogame
    {
        [Key]
        public long VideogameId { get; set; }
        public string Name { get; set; }
        public string? Overview { get; set; }
        public DateTime Release_date { get; set; }

        public long SoftwareHouseId { get; set; }
        public Softwarehouse Softwarehouse { get; set; }

        public override string ToString()
        {
            string formatDate = this.Release_date.ToString("dd-MMMM-yyyy");
            return $"Videogame - {this.VideogameId} : \n Name: {this.Name} \n Release date: {formatDate} \n Overview: {this.Overview} \n Software House: {this.Softwarehouse.Name}";
        }
    }
}
