using net_ef_videogame.Classes;
using net_ef_videogame.Database;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame.StaticClasses
{
    public static class VideogameManager
    {
        public static Videogame CreateVideogame()
        {
            Console.Write("What is the game name: ");
            string gameName = Console.ReadLine();

            Console.Write("What is the game description: ");
            string gameOverview = Console.ReadLine();

            Console.Write("When was the game released: ");
            DateTime gameReleaseDate;

            while (DateTime.TryParseExact(Console.ReadLine(), "dd/MMMM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out gameReleaseDate) == false)
            {
                Console.Write("Date is written wrong: ");
            }

            Console.Write("What is the game's software house id: ");
            long softwareHouseId;
            while (!long.TryParse(Console.ReadLine(), out softwareHouseId) || softwareHouseId <= 0)
            {
                Console.Write("Please insert a valid number: ");
            }

            Videogame dataVideogame = new()
            {
                Name = gameName,
                Overview = gameOverview,
                Release_date = gameReleaseDate,
                SoftwareHouseId = softwareHouseId,
            };

            return dataVideogame;
        } 
        
        public static Softwarehouse CreateSoftwareHouse()
        {
            Console.Write("What is the software house name: ");
            string softwareHouseName = Console.ReadLine();

            Console.Write("What is the city of in which the software house is located: ");
            string softwareHouseCity = Console.ReadLine();

            Console.Write("What is the country in which the software house is located: ");
            string softwareHouseCountry = Console.ReadLine();

            Console.Write("What is the software house Tax id: ");
            string softwareHouseTaxId = Console.ReadLine();


            Softwarehouse softwareHouse = new()
            {
                Name = softwareHouseName,
                City = softwareHouseCity,
                Country = softwareHouseCountry,
                Tax_id = softwareHouseTaxId,
                Videogames = new List<Videogame>()
            };

            return softwareHouse;
        }

    }
}
