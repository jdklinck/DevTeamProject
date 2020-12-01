using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeam
    {
        public int TeamId { get; set; }
        public List<Developer> Developers  { get; set; }

        public DevTeam()
        {

        }
        public DevTeam(int teamId, List<Developer> developers)
        {
            TeamId = teamId;
            Developers = developers;
        }
    }
}
