using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace RecruBuddy
{
    internal class MainMenuCommands
    {
        public static void consoleLogic(JobOffersService JobOffersService)
        {
            bool shouldAppBeRunnign = true;
            Console.WriteLine("Hello! What Can I do for you?");
            while (shouldAppBeRunnign)
            {
                writeOptionsToConsole();

                var userInput = Console.ReadKey();
                Console.WriteLine("");
                switch (userInput.KeyChar)
                {
                    case '1':

                        try
                        {
                            addJobOffer(JobOffersService);
                            Console.WriteLine("Job Offer added");
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message);
                        }
                        break;

                    case '2':
                        try
                        {
                            editJobOffer(JobOffersService);
                            Console.WriteLine("Job Offer edited");
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message);
                        }
                        break;

                    case '3':
                        try
                        {
                            showAllJobOffers(JobOffersService);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case '4':
                        try
                        {
                            deleteJobOffer(JobOffersService);
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

        public static void writeOptionsToConsole()
        {
            Console.WriteLine("------------------------");
            Console.WriteLine("Type 1 to add new Job offer");
            Console.WriteLine("Type 2 to edit job offers");
            Console.WriteLine("Type 3 to show all job offers");
            Console.WriteLine("Type 4 to delete an offer");
            Console.WriteLine("Type 9 to exit");
        }

        public static void addJobOffer(JobOffersService jobOffersService)
        {
            JobOffer jobOfferToAdd = GetDataForJobOffer();
            jobOffersService.AddNewJobOffer(jobOfferToAdd);
        }

        public static string getIdFromUser()
        {
            Console.WriteLine("Please enter id of job offer to edit:");
            var idJobToEdit = Console.ReadLine();

            if (String.IsNullOrEmpty(idJobToEdit))
            {
                throw new Exception(
                    "An error occured. I cannot add this job offer"
                );
            }

            return idJobToEdit;
        }

        public static void editJobOffer(JobOffersService jobOffersService)
        {
            JobOffer jobOfferToEdit;

            string idJobToEdit = getIdFromUser();

            int idElementToEdit = jobOffersService.FindIdOfJobOffer(
                idJobToEdit
            );

            jobOfferToEdit = GetDataForJobOffer();
            jobOffersService.OverrideJobOffer(idElementToEdit, jobOfferToEdit);
        }

        public static void showAllJobOffers(JobOffersService jobOffersService)
        {
            var jobOffers = jobOffersService.GetJobOfferList();
            if (jobOffers == null)
            {
                throw new Exception("There is currently no job offers.");
            }
            foreach (var JobOffer in jobOffers)
            {
                JobOffer.GetDetails();
            }
        }

        private static void ValidateStringInput(string input)
        {
            if (String.IsNullOrEmpty(input.Trim()))
            {
                throw new Exception("An error occured. I cannot add this job offer");
            };
        }

        public static JobOffer GetDataForJobOffer()
        {
            Console.WriteLine("Please enter company name:");
            string companyName = Console.ReadLine();
            ValidateStringInput(companyName);
            Console.WriteLine("Please enter Position Name:");
            string positionName = Console.ReadLine();
            ValidateStringInput(positionName);
            Console.WriteLine("Please enter Description:");
            string descripciton = Console.ReadLine();
            ValidateStringInput(descripciton);
            Console.WriteLine("Please enter status:");
            string status = Console.ReadLine();
            ValidateStringInput(status);

            JobOffer jobOfferToAdd = new JobOffer(
                companyName: companyName,
                positionName: positionName,
                description: descripciton,
                status: status
            );
            return jobOfferToAdd;
        }

        public static void deleteJobOffer(JobOffersService jobOffersService)
        {
            JobOffer jobOfferToDelete = null;
            Console.WriteLine("Please enter job offer id:");
            var JobToDelete = Console.ReadLine();

            if (String.IsNullOrEmpty(JobToDelete))
            {
                throw new Exception(
                    "An error occured. I cannot find this job offer"
                );
            }
            int JobToDeleteInt;
            int.TryParse(JobToDelete, out JobToDeleteInt);
            jobOfferToDelete = jobOffersService.FindOfferById(JobToDeleteInt);

            //int idElementToDelete = jobOffersService.FindIdOfJobOffer(
            //    JobToDelete
            //);

            //List<JobOffer> CurrentJobOfferList = jobOffersService.GetJobOfferList();
            //for (int i = 0; i < CurrentJobOfferList.Count; i++)
            //{
            //    if (CurrentJobOfferList[i].Id == idElementToDelete)
            //    {
            //        jobOfferToDelete = CurrentJobOfferList[i];
            //    }
            //}

            //if (jobOfferToDelete == null)
            //{
            //    throw new Exception(
            //        "An error occured. I cannot find this job offer"
            //    );
            //}

            jobOffersService.DeleteJobOffer(jobOfferToDelete);
        }

        static public void addToFile(object objectToArchive) {
            string objectSerialized = JsonConvert.SerializeObject(objectToArchive);
            File.WriteAllText("./../../../../objectSerialized.json", objectSerialized);
        }
    }
}