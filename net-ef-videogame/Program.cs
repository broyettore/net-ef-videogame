using Microsoft.EntityFrameworkCore;
using net_ef_videogame.Classes;
using net_ef_videogame.Database;
using net_ef_videogame.StaticClasses;

namespace net_ef_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Videogame Manager 2.0 \n");
            Console.WriteLine(@"These are the options provided by the manager:
                            - 0 : Show all videogames
                            - 1 : To Insert a new videogame
                            - 2 : To Insert a new Software house
                            - 3 : To search a videogame by id
                            - 4 : To search all videogames having an inserted input in their name
                            - 5 : To cancel a videogame by Id
                            - 6 : Print all the games created by a software house by id
                            - 7 : To close the program");
            Console.WriteLine(); // empty line

            bool condition = true;

            while (condition)
            {
                Console.WriteLine(); // empty line
                Console.Write("Insert a number to run the associated program: ");
                int choice;
                while ((int.TryParse(Console.ReadLine(), out choice)) == false)
                {
                    Console.WriteLine("Insert a number please");
                }
                Console.WriteLine(); // empty line

                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Here's the list of videogames and software houses");
                        Console.WriteLine(); // Empty Line

                        using (VideogameContext db = new())
                        {
                            List<Videogame> videogames = db.Videogames.ToList<Videogame>();
                            List<Softwarehouse> softwarehouses = db.Softwarehouses.ToList<Softwarehouse>();

                            Console.WriteLine("********* Videogames ********* \n");
                            foreach (Videogame game in videogames)
                            {
                                Console.WriteLine(game);
                                Console.WriteLine(); // empty line
                            }

                            Console.WriteLine(); // Empty Line

                            Console.WriteLine("********* Software Houses ********* \n");
                            foreach (Softwarehouse house in softwarehouses)
                            {
                                Console.WriteLine(house);
                                Console.WriteLine(); // empty line
                            }
                        }

                        break;

                    case 1:
                        Videogame newVideogame = VideogameManager.CreateVideogame();

                        using (VideogameContext db = new())
                        {
                            try
                            {
                                db.Add(newVideogame);
                                db.SaveChanges();

                                Console.WriteLine("A video game was succesfully added to the database");
                            }
                            catch (DbUpdateException ex)
                            {
                                // Handle Entity Framework-related exceptions
                                Console.WriteLine(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                            }
                            catch (Exception ex)
                            {
                                // Handle other exceptions
                                Console.WriteLine(ex.Message);
                            }
                        }

                        break;

                    case 2:
                        Softwarehouse newSoftwareHouse = VideogameManager.CreateSoftwareHouse();

                        using (VideogameContext db = new())
                        {
                            try
                            {
                                db.Add(newSoftwareHouse);
                                db.SaveChanges();

                                Console.WriteLine("A software house was successfully added to the database");
                            }
                            catch (DbUpdateException ex)
                            {
                                // Handle Entity Framework-related exceptions
                                Console.WriteLine(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                            }
                            catch (Exception ex)
                            {
                                // Handle other exceptions
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;

                    case 3:
                        Console.Write("Insert the Id of the videogame you want to find: ");
                        int gameId;

                        while (!int.TryParse(Console.ReadLine(), out gameId) || gameId <= 0)
                        {
                            Console.Write("Please insert a valid number: ");
                        }

                        using (VideogameContext db = new())
                        {
                            try
                            {
                                Videogame result = db.Videogames.Where(game => game.VideogameId == gameId).FirstOrDefault();

                                if (result != null)
                                {
                                    Console.WriteLine(); // empty line
                                    Console.WriteLine($"the game with this id-{gameId} is: {result.Name}");
                                }
                                else
                                {
                                    throw new Exception($"No game found with this id {gameId}");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(); // empty line
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;

                    case 4:
                        Console.Write("Insert the name of the videogame you want to find: ");
                        string gameName = Console.ReadLine();

                        while (string.IsNullOrEmpty(gameName))
                        {
                            Console.Write("Empty inputs are no valid, try again: ");
                            gameName = Console.ReadLine();
                        }

                        using (VideogameContext db = new())
                        {
                            try
                            {
                                List<Videogame> resultList = db.Videogames.Where(game => game.Name.Contains(gameName)).ToList();

                                if (resultList.Count > 0)
                                {
                                    Console.WriteLine(); // empty line
                                    Console.WriteLine($"the games matching your input are: ");
                                    foreach (Videogame game in resultList)
                                    {
                                        Console.WriteLine(game.Name);
                                    }
                                }
                                else
                                {
                                    throw new Exception($"No game found with input {gameName} were found");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(); // empty line
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;

                    case 5:
                        Console.Write("Insert the Id of the videogame you want to delete: ");
                        long gameIdToDelete;

                        while (!long.TryParse(Console.ReadLine(), out gameIdToDelete) || gameIdToDelete <= 0)
                        {
                            Console.Write("Please insert a valid number: ");
                        }

                        using (VideogameContext db = new())
                        {
                            try
                            {
                                // finds game to delete
                                Videogame gameToDelete = db.Videogames.FirstOrDefault(game => game.VideogameId == gameIdToDelete);

                                if (gameToDelete != null)
                                {
                                    db.Remove(gameToDelete);
                                    db.SaveChanges();

                                    Console.WriteLine($"The videogame with Id-{gameIdToDelete} was successfully deleted");

                                }
                                else
                                {
                                    throw new Exception($"Fail, No game with this id-{gameIdToDelete} was found");
                                }

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;

                    case 6:

                        using (VideogameContext db = new())
                        {
                            Console.WriteLine("Here are all the softwares houses");
                            List<Softwarehouse> list = db.Softwarehouses.ToList<Softwarehouse>();

                            foreach (Softwarehouse house in list)
                            {
                                Console.WriteLine(); // empty line
                                Console.WriteLine(house);
                            }
                            Console.WriteLine(); // empty line

                            Console.Write("Insert the Id of a sofware house to see the games they created: ");
                            long softwareHouseId;

                            while (!long.TryParse(Console.ReadLine(), out softwareHouseId) || softwareHouseId <= 0)
                            {
                                Console.Write("Please insert a valid number: ");
                            }

                            try
                            {
                                Softwarehouse houseFound = db.Softwarehouses.FirstOrDefault(house => house.SoftwareHouseId == softwareHouseId);
                                List<Videogame> gamesFound = db.Videogames.Where(game => game.SoftwareHouseId == softwareHouseId).ToList();

                                if (houseFound != null)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine($"****** {houseFound.Name} ****** \n");
                                    foreach (Videogame game in gamesFound)
                                    {
                                        Console.WriteLine(); // empty line
                                        Console.WriteLine(game);
                                    }
                                }
                                else
                                {
                                    throw new Exception($"Fail, No softwar eHouse with this id-{softwareHouseId} was found");
                                }

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;

                    case 7:
                        condition = false;
                        break;

                    default:
                        Console.WriteLine("You did not insert a correct number");
                        break;
                }
            }

            if (condition == false) { Console.WriteLine("Program Terminated"); }
        }
    }
}