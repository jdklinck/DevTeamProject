using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class Developer
    {
        public string Name { get; set; }
        public int IdNumber { get; set; }
        public bool HasPluralsight { get; set; }

        public Developer()
        {

        }
        public Developer(string name, int idNumber, bool hasPluralsight)
        {
            Name = name;
            IdNumber = idNumber;
            HasPluralsight = hasPluralsight;
        }
    }

}
