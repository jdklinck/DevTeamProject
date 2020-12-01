using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeamRepo
    {
        private readonly List<DevTeam> _devTeamsRepo = new List<DevTeam>();

        //DevTeam Create
        public void AddTeamToRepo(DevTeam devTeam)
        {
            _devTeamsRepo.Add(devTeam);
        }
        //DevTeam Read
        public List<DevTeam> GetDevTeams()
        {
            return _devTeamsRepo;
        }
        //DevTeam Update
        public bool UpdateExisitingDevTeam(int originalTeamNumber, DevTeam newDevTeam)
        {
            DevTeam oldDevTeam = GetDevTeamsById(originalTeamNumber);
            if (oldDevTeam != null)
            {
                oldDevTeam.TeamId = newDevTeam.TeamId;
                oldDevTeam.Developers = newDevTeam.Developers;
                return true;
            }
            else
            {
                return false;
            }
        }

        //DevTeam Helper (Get Team by ID)
        public DevTeam GetDevTeamsById(int originalTeamNumber)
        {
            foreach (DevTeam team in _devTeamsRepo)
            {
                if (team.TeamId == originalTeamNumber)
                {
                    return team;
                }
            }
            return null;
        }

        //DevTeam Delete
        public bool RemoveTeam(int teamId)
        {
            DevTeam devTeam = GetDevTeamsById(teamId);
            if (devTeam == null)
            {
                return false;
            }
            int intitalCount = _devTeamsRepo.Count;
            _devTeamsRepo.Remove(devTeam);
            if (intitalCount > _devTeamsRepo.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool AddDevToTeam(int teamId, Developer developer)
        {
            DevTeam devTeam = GetDevTeamsById(teamId);
            if (devTeam == null)
            {
                return false;
            }
            int intitialCount = devTeam.Developers.Count;
            devTeam.Developers.Add(developer);
            if (intitialCount < devTeam.Developers.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveDevFromTeam(int teamId, Developer developer)
        {
            DevTeam devTeam = GetDevTeamsById(teamId);
            if (devTeam == null)
            {
                return false;
            }
            int intitialCount = devTeam.Developers.Count;
            devTeam.Developers.Remove(developer);
            if (intitialCount > devTeam.Developers.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void AddMultipleDevToTeam(int teamId, List<Developer> developers)
        {
            DevTeam devTeam = GetDevTeamsById(teamId);
            if (devTeam != null)
            {
                foreach (var developer in developers)
                {
                    devTeam.Developers.Add(developer);
                }
            }
            else
            {
                Console.WriteLine($"Sorry there's no available team with the Id. {devTeam.TeamId}");
            }
        }
        public void RemoveMultipleDevToTeam(int teamId, List<Developer> developers) 
        {
            DevTeam devTeam = GetDevTeamsById(teamId);
            if (devTeam != null)
            {
                foreach (var developer in developers)
                {
                    devTeam.Developers.Remove(developer);
                }
            }
            else
            {
                Console.WriteLine($"Sorry there's no available team with the Id. {devTeam.TeamId}");
            }
        }
    }
}
