using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruBuddy
{
    interface IJobOffer
    {
        Guid Id { get; set; }
        string CompanyName { get; set; }
        string PositionName { get; set; }
        string Description { get; set; }
        string Status { get; set; }
    }
}
