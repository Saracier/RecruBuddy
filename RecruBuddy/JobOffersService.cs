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

        public void AddNewJobOffer(JobOffer JobOffer)
        {
            _db.Add(JobOffer);
            _db.SaveChanges();
        }

        public void OverrideJobOffer(int id, JobOffer jobOfferToEdit)
        {
            JobOffer JobOfferInDb = _db.JobOffers.FirstOrDefault(j => j.Id == id);
            if (JobOfferInDb == null)
            {
                throw new Exception("entry does not exist on database");
            }
            ;
            JobOfferInDb.CompanyName = jobOfferToEdit.CompanyName;
            JobOfferInDb.PositionName = jobOfferToEdit.PositionName;
            JobOfferInDb.Description = jobOfferToEdit.Description;
            JobOfferInDb.Status = jobOfferToEdit.Status;

            _db.SaveChanges();
        }

        public int FindIdOfJobOffer(string idParameter)
        {
            int idJobToProceed;

            if (!int.TryParse(idParameter, out idJobToProceed))
            {
                throw new Exception("An error occured. I cannot proceed with this job offer");
            }

            List<JobOffer> JobOffers = GetJobOfferList();
            for (int i = 0; i < JobOffers.Count; i++)
            {
                if (idJobToProceed == JobOffers[i].Id)
                {
                    return JobOffers[i].Id;
                }
            }

            throw new Exception("No such offer was found");
        }

        public void DeleteJobOffer(JobOffer jobOfferToDelete)
        {
            JobOffer? JobOfferToProceed = _db.JobOffers.FirstOrDefault(
                j => j.Id == jobOfferToDelete.Id
            );
            if (JobOfferToProceed == null)
            {
                throw new Exception("An error occured. I cannot proceed with this job offer");
            }

            _db.Remove(JobOfferToProceed);
            _db.SaveChanges();
        }

        public JobOffer FindOfferById(int id) {
            JobOffer jobOffer =   _db.JobOffers.FirstOrDefault(o => o.Id == id);
            if (jobOffer is null)
            {
                throw new Exception(
                    "An error occured. I cannot find this job offer"
                );
            }

            return jobOffer;
        }
    }
}