namespace RecruBuddy
{
    internal class MainMenuCommands
    {

        
        public static void addJobOffer(JobOffersService JobOffersService)
        {
            JobOffer jobOfferToAdd;
            jobOfferToAdd = JobOffersService.GetDataForJobOffer();
            JobOffersService.AddNewJobOffer(jobOfferToAdd);
            Console.WriteLine("Job Offer added");
        }
    }
}