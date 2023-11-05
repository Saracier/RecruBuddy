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
            using var db = new JobOfferContext();
            Console.WriteLine("Hello! What Can I do for you?");
            bool shouldAppBeRunnign = true;
            var JobOffersService = new JobOffersService();
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
                        try
                        {
                            JobOffer jobOfferToEdit;

                            Console.WriteLine("Please enter id of job offer to edit:");
                            var nameJobToEdit = Console.ReadLine();

                            if (String.IsNullOrEmpty(nameJobToEdit))
                            {
                                throw new Exception("An error occured. I cannot add this job offer");
                            }

                            Guid idElementToEdit = JobOffersService.FindNumberOfJobOffer(nameJobToEdit);

                            //if (idElementToEdit == -1)
                            //{
                            //    Console.WriteLine("Sorry, I haven't found such item");
                            //    break;
                            //}

                            // try
                            //{
                                jobOfferToEdit = JobOffersService.GetDataForJobOffer();
                            //}
                            //catch (Exception error)
                            //{
                            //    Console.WriteLine(error.Message);
                            //    continue;
                            //}
                            JobOffersService.OverrideJobOffer(idElementToEdit, jobOfferToEdit);
                            Console.WriteLine("Job Offer edited");
                            break;
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message);
                            break;
                        }
                        

                    case '3':
                        var jobOffers = JobOffersService.GetJobOfferList();
                        foreach (var JobOffer in jobOffers)
                        {
                            JobOffer.GetDetails();
                        }
                        break;

                    case '4':
                        try
                        {
                            JobOffer jobOfferToDelete = null ;
                            Console.WriteLine("Please enter job offer name to edit:");
                            var JobToDelete = Console.ReadLine();

                            if (String.IsNullOrEmpty(JobToDelete))
                            {
                                throw new Exception("An error occured. I cannot find this job offer");
                            }

                            Guid idElementToDelete = JobOffersService.FindNumberOfJobOffer(JobToDelete);

                            //if (idElementToDelete == -1)
                            //{
                            //    throw new Exception("Sorry, I haven't found such item");

                            //}
                            //
                            // Pytanie do Yanexa:
                            // Czemu mimo, że jak walnę literówkę w usuwanym opisie, to i tak mi przechodzi throw i kontynuuje mi się program do tej linijki?


                            List<JobOffer> CurrentJobOfferList = JobOffersService.GetJobOfferList();
                            for (int i = 0; i < CurrentJobOfferList.Count; i++)
                            {
                                if (CurrentJobOfferList[i].Id == idElementToDelete)
                                {
                                     jobOfferToDelete = CurrentJobOfferList[i];
                                }
                            }

                            if(jobOfferToDelete == null) 
                            {
                                throw new Exception("An error occured. I cannot find this job offer");
                            }

                            JobOffersService.DeleteJobOffer(jobOfferToDelete);
                            Console.WriteLine("Job Offer deleted");
                            break;
                        }
                        catch (Exception error) 
                        {
                            Console.WriteLine(error.Message);
                            break;

                        }
                        

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