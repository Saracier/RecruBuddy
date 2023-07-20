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
        private int id = 0;
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

            var jobOfferToAdd = new JobOffer(Id: id, CompanyName: companyName, PositionName: positionName, Description: descripciton, Status: status);
            return jobOfferToAdd;
        }

        public void AddNewJobOffer(JobOffer JobOffer)
        {
            this.jobOfferList.Add(JobOffer);
            id++;
        }

        private void ValidateStringInput(string input) {
            if(String.IsNullOrEmpty(input)) {
                throw new Exception("An error occured. I cannot add this job offer");
            };
        }

        public void OverrideJobOffer(int id, JobOffer JobOfferToEdit)
        {
            jobOfferList[id] = JobOfferToEdit;
        }

        public int FindNumberOfJobOffer(string nameParameter)
        {
            int idJobToDelete;
            bool isSuccesyfullyParsed = int.TryParse(nameParameter, out idJobToDelete);

            if (!isSuccesyfullyParsed)
            {
                throw new Exception("An error occured. I cannot add this job offer");
            }
            int idElementToEdit = -1;

            List<JobOffer> JobOffers = this.GetJobOfferList();
            for (int i = 0; i < JobOffers.Count; i++)
            {
                if (idJobToDelete == JobOffers[i].Id)
                {
                    idElementToEdit = i;
                    break;
                }
            }

            return idElementToEdit;
        }

        public void DeleteJobOffer(JobOffer JobOfferToDelete)
        {
            this.jobOfferList.Remove(JobOfferToDelete);
        }
    }
}
