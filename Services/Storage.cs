using RockFood.Interfaces;
using RockFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Services
{
    public class Storage : IStoredable
    {       
            public List<Food> Foods { get; set; }
            public Storage()
            {
                Foods = new List<Food>();
            }
    }
}
