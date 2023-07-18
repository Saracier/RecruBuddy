using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruBuddy
{
    interface IJobOffer
    {
        string Name { get; set; }
        string CompanyName { get; set; }
        string PositionName { get; set; }
        string Description { get; set; }
        string Status { get; set; }

    }
    public class JobOffer : IJobOffer
    {
        public JobOffer(string Name, string CompanyName, string PositionName, string Status, string Description)
        {
            this.Name = Name;
            this.CompanyName = CompanyName;
            this.PositionName = PositionName;
            this.Status = Status;
            this.Description = Description;
        }

        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string PositionName { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public void GetDetails()
        {
            Console.WriteLine($"Name of this job offer is {Name}");
            Console.WriteLine($"CompanyName of this job offer is {CompanyName}");
            Console.WriteLine($"PositionName of this job offer is {PositionName}");
            Console.WriteLine($"Description of this job offer is {Description}");
            Console.WriteLine($"Status of this job offer is {Status}");
            Console.WriteLine("");
        }


    }
}
