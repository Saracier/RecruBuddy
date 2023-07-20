using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Xml.Linq;

namespace RecruBuddy
{
    public class RecruBuddy
    {
        static void Main()
        {
            Console.WriteLine("Hello! What Can I do for you?");
            bool shouldAppBeRunnign = true;
            var JobOffersService = new JobOffersService();
            List<JobOffer> jobOffers = JobOffersService.GetJobOfferList();
            while (shouldAppBeRunnign)
            {
                Console.WriteLine("");
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

                        JobOffer jobOfferToAdd;
                        try
                        {
                            jobOfferToAdd = JobOffersService.GetDataForJobOffer();
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message);
                            continue;
                        }
                        JobOffersService.AddNewJobOffer(jobOfferToAdd);
                        Console.WriteLine("Job Offer added");
                        break;

                    case '2':

                        JobOffer jobOfferToEdit;

                        Console.WriteLine("Please enter job offer name to edit:");
                        var nameJobToEdit = Console.ReadLine();

                        if (String.IsNullOrEmpty(nameJobToEdit))
                        {
                            throw new Exception("An error occured. I cannot add this job offer");
                        }

                        int idElementToEdit = JobOffersService.FindNumberOfJobOffer(nameJobToEdit);

                        if (idElementToEdit == -1)
                        {
                            Console.WriteLine("Sorry, I haven't found such item");
                            break;
                        }

                        try
                        {
                            jobOfferToEdit = JobOffersService.GetDataForJobOffer();
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message);
                            continue;
                        }
                        JobOffersService.OverrideJobOffer(idElementToEdit, jobOfferToEdit);
                        Console.WriteLine("Job Offer edited");
                        break;

                    case '3':
                        jobOffers = JobOffersService.GetJobOfferList();
                        foreach (var JobOffer in jobOffers)
                        {
                            JobOffer.GetDetails();
                        }
                        break;

                    case '4':
                        JobOffer jobOfferToDelete;
                        Console.WriteLine("Please enter job offer name to edit:");
                        var JobToDelete = Console.ReadLine();

                        if (String.IsNullOrEmpty(JobToDelete))
                        {
                            throw new Exception("An error occured. I cannot add this job offer");
                        }

                        int idElementToDelete = JobOffersService.FindNumberOfJobOffer(JobToDelete);

                        if (idElementToDelete == -1)
                        {
                            Console.WriteLine("Sorry, I haven't found such item");
                            break;
                        }

                        jobOfferToDelete = JobOffersService.GetJobOfferList()[idElementToDelete];

                        JobOffersService.DeleteJobOffer(jobOfferToDelete);
                        Console.WriteLine("Job Offer deleted");
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