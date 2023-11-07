using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RecruBuddy
{
    public class JobOffersService
    {
        //private List<JobOffer> jobOfferList = new List<JobOffer>();

        public List<JobOffer> GetJobOfferList(JobOfferContext db)
        {
            return db.JobOffers.ToList();
            //return jobOfferList;
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
                CompanyName: companyName,
                PositionName: positionName,
                Description: descripciton,
                Status: status
            );
            return jobOfferToAdd;
        }

        public void AddNewJobOffer(JobOffer JobOffer, JobOfferContext db)
        {
            //this.jobOfferList.Add(JobOffer);
            db.Add(JobOffer);
            db.SaveChanges();
        }

        private void ValidateStringInput(string input)
        {
            if (String.IsNullOrEmpty(input.Trim()))
            {
                throw new Exception("An error occured. I cannot add this job offer");
            };
        }

        public void OverrideJobOffer(Guid id, JobOffer JobOfferToEdit, JobOfferContext db)
        {
            JobOffer JobOfferInDb = db.JobOffers.FirstOrDefault(j => j.Id == id);
            if (JobOfferInDb == null)
            {
                throw new Exception("entry does not exist on database");
            }
            ;
            JobOfferInDb.CompanyName = JobOfferToEdit.CompanyName;
            JobOfferInDb.PositionName = JobOfferToEdit.PositionName;
            JobOfferInDb.Description = JobOfferToEdit.Description;
            JobOfferInDb.Status = JobOfferToEdit.Status;

            db.SaveChanges();
            //List<JobOffer> CurrentJobOfferList = GetJobOfferList();
            //for (int i = 0; i < CurrentJobOfferList.Count; i++)
            //    {
            //    if (CurrentJobOfferList[i].Id == id)
            //    {
            //        jobOfferList[i] = JobOfferToEdit;
            //    }
            //}
        }

        public Guid FindIdOfJobOffer(string idParameter, JobOfferContext db)
        {
            Guid idJobToProceed;
            bool isSuccesyfullyParsed = Guid.TryParse(idParameter, out idJobToProceed);

            if (!isSuccesyfullyParsed)
            {
                Console.WriteLine("An error occured. I cannot proceed with this job offer");
            }

            List<JobOffer> JobOffers = this.GetJobOfferList(db);
            for (int i = 0; i < JobOffers.Count; i++)
            {
                if (idJobToProceed == JobOffers[i].Id)
                {
                    return JobOffers[i].Id;
                }
            }

            throw new Exception("No such offer was found");
        }

        public void DeleteJobOffer(JobOffer JobOfferToDelete, JobOfferContext db)
        {
            JobOffer? JobOfferToProceed = db.JobOffers.FirstOrDefault(
                j => j.Id == JobOfferToDelete.Id
            );
            if (JobOfferToProceed == null)
            {
                throw new Exception("An error occured. I cannot proceed with this job offer");
            }

            db.Remove(JobOfferToProceed);
            db.SaveChanges();
            //this.jobOfferList.Remove(JobOfferToDelete);
        }
    }
}
