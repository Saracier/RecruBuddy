namespace RecruBuddy
{
    internal class MainMenuCommands
    {


        public static void addJobOffer(JobOffersService JobOffersService)
        {
            JobOffer jobOfferToAdd = JobOffersService.GetDataForJobOffer();
            JobOffersService.AddNewJobOffer(jobOfferToAdd);
            Console.WriteLine("Job Offer added");
        }

        public static void editJobOffer(JobOffersService JobOffersService)
        {
            JobOffer jobOfferToEdit;

            Console.WriteLine("Please enter id of job offer to edit:");
            var idJobToEdit = Console.ReadLine();

            if (String.IsNullOrEmpty(idJobToEdit))
            {
                throw new Exception(
                    "An error occured. I cannot add this job offer"
                );
            }

            int idElementToEdit = JobOffersService.FindIdOfJobOffer(
                idJobToEdit
            );

            jobOfferToEdit = JobOffersService.GetDataForJobOffer();

            JobOffersService.OverrideJobOffer(idElementToEdit, jobOfferToEdit);
            Console.WriteLine("Job Offer edited");
        }

        public static void showAllJobOffers(JobOffersService JobOffersService)
        {
            var jobOffers = JobOffersService.GetJobOfferList();
            if (jobOffers == null)
            {
                throw new Exception("There is currently no job offers.");
            }
            foreach (var JobOffer in jobOffers)
            {
                JobOffer.GetDetails();
            }
        }



        public static void deleteJobOffer(JobOffersService JobOffersService)
        {
            JobOffer jobOfferToDelete = null;
            Console.WriteLine("Please enter job offer id to edit:");
            var JobToDelete = Console.ReadLine();

            if (String.IsNullOrEmpty(JobToDelete))
            {
                throw new Exception(
                    "An error occured. I cannot find this job offer"
                );
            }

            int idElementToDelete = JobOffersService.FindIdOfJobOffer(
                JobToDelete
            );

            List<JobOffer> CurrentJobOfferList = JobOffersService.GetJobOfferList(

            );
            for (int i = 0; i < CurrentJobOfferList.Count; i++)
            {
                if (CurrentJobOfferList[i].Id == idElementToDelete)
                {
                    jobOfferToDelete = CurrentJobOfferList[i];
                }
            }

            if (jobOfferToDelete == null)
            {
                throw new Exception(
                    "An error occured. I cannot find this job offer"
                );
            }

            JobOffersService.DeleteJobOffer(jobOfferToDelete);
        }
    }
}