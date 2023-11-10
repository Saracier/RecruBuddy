using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace RecruBuddy
{
    public class RecruBuddy
    {
        static void Main()
        {
            using JobOfferContext db = new JobOfferContext();
            bool shouldAppBeRunnign = true;
            var JobOffersService = new JobOffersService(db);

            Console.WriteLine("Hello! What Can I do for you?");
            while (shouldAppBeRunnign)
            {
                Console.WriteLine("------------------------");
                Console.WriteLine("Type 1 to add new Job offer");
                Console.WriteLine("Type 2 to edit job offers");
                Console.WriteLine("Type 3 to show all job offers");
                Console.WriteLine("Type 4 to delete an offer");
                Console.WriteLine("Type 9 to exit");
                var userInput = Console.ReadKey();
                Console.WriteLine("");
                switch (userInput.KeyChar)
                {
                    case '1':

                        try
                        {
                            MainMenuCommands.addJobOffer(JobOffersService);
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message);
                        }
                        break;

                    case '2':
                        try
                        {
                            MainMenuCommands.editJobOffer(JobOffersService);
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message);
                        }
                        break;

                    case '3':
                        try
                        {MainMenuCommands.showAllJobOffers(JobOffersService);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case '4':
                        try
                        {
                            MainMenuCommands.deleteJobOffer(JobOffersService);
                            Console.WriteLine("Job Offer deleted");
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message);
                        }
                        break;

                    case '9':
                        Console.WriteLine("bye");
                        shouldAppBeRunnign = false;
                        break;

                    default:
                        Console.WriteLine("I'm sorry. I can not recognize such value");
                        break;
                }
            }
        }
    }
}
