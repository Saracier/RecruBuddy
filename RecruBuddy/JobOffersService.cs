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
        private List<JobOffer> jobOfferList = new List<JobOffer>();

        public List<JobOffer> GetJobOfferList() { return jobOfferList; }

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

            var jobOfferToAdd = new JobOffer(CompanyName: companyName, PositionName: positionName, Description: descripciton, Status: status);
            return jobOfferToAdd;
        }

        public void AddNewJobOffer(JobOffer JobOffer)
        {
            this.jobOfferList.Add(JobOffer);
        }

        private void ValidateStringInput(string input) {
            if(String.IsNullOrEmpty(input.Trim())) {
                throw new Exception("An error occured. I cannot add this job offer");
            };
        }

        public void OverrideJobOffer(Guid id, JobOffer JobOfferToEdit)
        {
            List<JobOffer> CurrentJobOfferList = GetJobOfferList();
            for (int i = 0; i < CurrentJobOfferList.Count; i++)
                {
                if (CurrentJobOfferList[i].Id == id) 
                {
                    jobOfferList[i] = JobOfferToEdit;
                }
            }
        }

        public Guid FindNumberOfJobOffer(string nameParameter)
        {
            Guid idJobToDelete;
            bool isSuccesyfullyParsed = Guid.TryParse(nameParameter, out idJobToDelete);

            if (!isSuccesyfullyParsed)
            {
                Console.WriteLine("An error occured. I cannot add this job offer");
            }
            Guid idElementToEdit;

            List<JobOffer> JobOffers = this.GetJobOfferList();
            for (int i = 0; i < JobOffers.Count; i++)
            {
                if (idJobToDelete == JobOffers[i].Id)
                {
                    idElementToEdit = JobOffers[i].Id;
                    return idElementToEdit;
                }
            }

            throw new Exception("No such offer was found");
        }

        public void DeleteJobOffer(JobOffer JobOfferToDelete)
        {
            this.jobOfferList.Remove(JobOfferToDelete);
        }
    }
}
