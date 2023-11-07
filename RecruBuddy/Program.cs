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
                        JobOffersService.AddNewJobOffer(jobOfferToAdd, db);
                        Console.WriteLine("Job Offer added");
                        break;

                    case '2':
                        try
                        {
                            JobOffer jobOfferToEdit;

                            Console.WriteLine("Please enter id of job offer to edit:");
                            var idJobToEdit = Console.ReadLine();

                            if (String.IsNullOrEmpty(idJobToEdit))
                            {
                                throw new Exception("An error occured. I cannot add this job offer");
                            }

                            Guid idElementToEdit = JobOffersService.FindNumberOfJobOffer(idJobToEdit, db);


                                jobOfferToEdit = JobOffersService.GetDataForJobOffer();

                            JobOffersService.OverrideJobOffer(idElementToEdit, jobOfferToEdit, db);
                            Console.WriteLine("Job Offer edited");
                            break;
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message);
                            break;
                        }
                        

                    case '3':
                        var jobOffers = JobOffersService.GetJobOfferList(db);
                        if (jobOffers == null) {
                            Console.WriteLine("There is currently no job offers.");
                            break;
                        }
                        foreach (var JobOffer in jobOffers)
                        {
                            JobOffer.GetDetails();
                        }
                        break;

                    case '4':
                        try
                        {
                            JobOffer jobOfferToDelete = null ;
                            Console.WriteLine("Please enter job offer id to edit:");
                            var JobToDelete = Console.ReadLine();

                            if (String.IsNullOrEmpty(JobToDelete))
                            {
                                throw new Exception("An error occured. I cannot find this job offer");
                            }

                            Guid idElementToDelete = JobOffersService.FindIdOfJobOffer(JobToDelete, db);

                            List<JobOffer> CurrentJobOfferList = JobOffersService.GetJobOfferList(db);
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

                            JobOffersService.DeleteJobOffer(jobOfferToDelete, db);
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