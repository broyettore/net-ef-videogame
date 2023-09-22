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
    [Table("softwarehouses")]
    public class Softwarehouse
    {
        [Key]
        public long SoftwareHouseId { get; set; }
        public string Name { get; set;}
        public string City { get; set;}
        public string Country { get; set;}
        public string Tax_id { get; set;}

        public List<Videogame> Videogames { get; set;}

        public override string ToString()
        {
            return $"Software House id: {this.SoftwareHouseId} \n Name: {this.Name} \n City: {this.City} \n Country: {this.Country} \n Tax Id: {this.Tax_id}";
        }
    }
}
