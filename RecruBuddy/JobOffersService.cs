namespace RecruBuddy
{
    public class JobOffersService
    {
        //private List<JobOffer> jobOfferList = new List<JobOffer>();
        private readonly JobOfferContext _db;

        public JobOffersService(JobOfferContext db)
        {
            _db = db;
        }

        public List<JobOffer> GetJobOfferList()
        {
            return _db.JobOffers.ToList();
        }

        public JobOffer GetDataForJobOffer()
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

        public void AddNewJobOffer(JobOffer JobOffer)
        {
            _db.Add(JobOffer);
            _db.SaveChanges();
        }

        private void ValidateStringInput(string input)
        {
            if (String.IsNullOrEmpty(input.Trim()))
            {
                throw new Exception("An error occured. I cannot add this job offer");
            };
        }

        public void OverrideJobOffer(int id, JobOffer JobOfferToEdit)
        {
            JobOffer JobOfferInDb = _db.JobOffers.FirstOrDefault(j => j.Id == id);
            if (JobOfferInDb == null)
            {
                throw new Exception("entry does not exist on database");
            }
            ;
            JobOfferInDb.CompanyName = JobOfferToEdit.CompanyName;
            JobOfferInDb.PositionName = JobOfferToEdit.PositionName;
            JobOfferInDb.Description = JobOfferToEdit.Description;
            JobOfferInDb.Status = JobOfferToEdit.Status;

            _db.SaveChanges();
        }

        public int FindIdOfJobOffer(string idParameter)
        {
            int idJobToProceed;

            if (!int.TryParse(idParameter, out idJobToProceed))
            {
                throw new Exception("An error occured. I cannot proceed with this job offer");
            }

            List<JobOffer> JobOffers = this.GetJobOfferList();
            for (int i = 0; i < JobOffers.Count; i++)
            {
                if (idJobToProceed == JobOffers[i].Id)
                {
                    return JobOffers[i].Id;
                }
            }

            throw new Exception("No such offer was found");
        }

        public void DeleteJobOffer(JobOffer JobOfferToDelete)
        {
            JobOffer? JobOfferToProceed = _db.JobOffers.FirstOrDefault(
                j => j.Id == JobOfferToDelete.Id
            );
            if (JobOfferToProceed == null)
            {
                throw new Exception("An error occured. I cannot proceed with this job offer");
            }

            _db.Remove(JobOfferToProceed);
            _db.SaveChanges();
        }
    }
}