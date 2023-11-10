using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruBuddy
{
    public class JobOffer : IJobOffer
    {


        public JobOffer(string companyName, string positionName, string status, string description)
        {
            CompanyName = companyName;
            PositionName = positionName;
            Status = status;
            Description = description;
        }

        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string PositionName { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public void GetDetails()
        {
            Console.WriteLine($"Id of this job offer is: {Id}");
            Console.WriteLine($"CompanyName of this job offer is: {CompanyName}");
            Console.WriteLine($"PositionName of this job offer is: {PositionName}");
            Console.WriteLine($"Description of this job offer is: {Description}");
            Console.WriteLine($"Status of this job offer is: {Status}");
            Console.WriteLine("");
        }
    }
}
