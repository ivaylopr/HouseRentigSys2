using HouseRentingSys2.Core.Models.Agent;
using HouseRentingSys2.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSys2.Core.Models.House
{
    public class HouseDetailsServiceModel : HouseServiceModel
    {
        public string Description { get; set; } = null!;
        public string  Category { get; set; }= null!;
        public AgentServiceModel Agent { get; set; } = null!;
    }
}
