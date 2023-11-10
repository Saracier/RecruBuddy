namespace RecruBuddy
{
    public class RecruBuddy
    {
        private static void Main()
        {
            using JobOfferContext db = new JobOfferContext();
            var JobOffersService = new JobOffersService(db);
            MainMenuCommands.consoleLogic(JobOffersService);
        }
    }
}