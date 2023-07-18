using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruBuddy
{
    public class JobOffersService
    {
        private List<JobOffer> JobOfferList = new List<JobOffer>();

        public List<JobOffer> GetJobOfferList() { return JobOfferList; }

        public JobOffer GetDataForJobOffer()
        {
            Console.WriteLine("Please enter name for Job Offer:");
            string name = Console.ReadLine();
            Console.WriteLine("Please enter company name:");
            string companyName = Console.ReadLine();
            Console.WriteLine("Please enter Position Name:");
            string positionName = Console.ReadLine();
            Console.WriteLine("Please enter Description:");
            string descripciton = Console.ReadLine();
            Console.WriteLine("Please enter status:");
            string status = Console.ReadLine();

            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(companyName) || String.IsNullOrEmpty(positionName) || String.IsNullOrEmpty(descripciton) || String.IsNullOrEmpty(status))
            {
                throw new Exception("An error occured. I cannot add this job offer");
            }

            var JobOfferToAdd = new JobOffer(Name: name, CompanyName: companyName, PositionName: positionName, Description: descripciton, Status: status);
            return JobOfferToAdd;
        }

        public void AddNewJobOffer(JobOffer JobOffer)
        {
            this.JobOfferList.Add(JobOffer);
        }

        public void OvveriteJobOffer(int id, JobOffer JobOfferToEdit)
        {
            JobOfferList[id] = JobOfferToEdit;
        }

        public int FindNumberOfJobOffer(string nameParameter)
        {
            int idElementToEdit = -1;

            List<JobOffer> JobOffers = this.GetJobOfferList();
            for (int i = 0; i < JobOffers.Count; i++)
            {
                if (nameParameter == JobOffers[i].Name)
                {
                    idElementToEdit = i;
                    break;
                }
            }
            return idElementToEdit;
        }

        public void DeleteJobOffer(JobOffer JobOfferToDelete)
        {
            this.JobOfferList.Remove(JobOfferToDelete);
        }
    }
}
