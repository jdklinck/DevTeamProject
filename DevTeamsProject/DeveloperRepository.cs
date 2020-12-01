using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DeveloperRepository
    {
        private readonly List<Developer> _developerRepo = new List<Developer>();

        //Developer Create
        public void AddDeveloperToRepo(Developer developer)
        {
            _developerRepo.Add(developer);
        }
        //Developer Read
        public List<Developer> GetDevelopers()
        {
            return _developerRepo;
        }

        //Developer Update
        public bool UpdateExistingDeveloper(int originalIdNumber, Developer newDeveloper)
        {
            //Find the content
            Developer oldDeveloper = GetDeveloperById(originalIdNumber);
            //Update the content
            if (oldDeveloper != null)
            {
                oldDeveloper.Name = newDeveloper.Name;
                oldDeveloper.IdNumber = newDeveloper.IdNumber;
                oldDeveloper.HasPluralsight = newDeveloper.HasPluralsight;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Developer Delete
        public bool RemoveDeveloper(int idNumber)
        {
            Developer developer = GetDeveloperById(idNumber);

            if (developer == null)
            {
                return false;
            }
            //See the count before the deletion
            int initalCount = _developerRepo.Count;
            _developerRepo.Remove(developer);
            //See if the developer is deleted
            if (initalCount > _developerRepo.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Developer Helper (Get Developer by ID)
        public Developer GetDeveloperById(int idNumber)
        {
            foreach (Developer developer in _developerRepo)
            {
                if (developer.IdNumber == idNumber)
                {
                    return developer;
                }
            }
            return null;
        }


        //Return a list of Developers without a Pluralsight license.
        public List<Developer> GetDevelopersWithoutPSL()
        {
            List<Developer> developers = new List<Developer>();
            //WE are going to loop through all the developers in the repo 
            foreach (var developer in _developerRepo)
            {
                //If the developer doesn't have Pluralsight
                if (developer.HasPluralsight == false)
                {
                    //We are going to add to the list
                    developers.Add(developer);
                }

            }
            return developers;

        }

       
    }
}
