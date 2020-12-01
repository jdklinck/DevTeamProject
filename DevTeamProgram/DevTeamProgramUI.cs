using DevTeamsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamProgram
{
    public class DevTeamProgramUI
    {
        private readonly DeveloperRepository _developerRepository = new DeveloperRepository();
        private readonly DevTeamRepo _devTeamRepository = new DevTeamRepo();

        public void Run()
        {
            SeedDeveloperList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //Display our options to the user
                Console.WriteLine("Please chose from the menu.\n" +
                    "1. Create New Developer\n" +
                    "2. View All Developers\n" +
                    "3. View Developers by ID Number\n" +
                    "4. Update Existing Developer\n" +
                    "5. Delete Existing Developer\n" +
                    "6. View All Developer Teams\n" +
                    "7. View Individual Developer Team \n" +
                    "8. Add Developer to a Team\n" +
                    "9. Add Multiple Developers to a Team \n" +
                    "10. Remove Developer from a Team \n" +
                    "11. Remove Multiple Developers from a Team \n" +
                    "12. View Developers Without Pluralsight\n" +
                    "13. Exit Menu");

                //Get the user's input
                string input = Console.ReadLine();

                //Evaluate the user's input and act accordingly

                switch (input)
                {
                    case "1":
                        CreateNewDeveloper();
                            break;
                    case "2":
                        ViewAllDevelopers();
                        break;
                    case "3":
                        ViewDeveloperById();
                        break;
                    case "4":
                        UpdateExistingDeveloper();
                        break;
                    case "5":
                        DeleteExistingDeveloper();
                        break;
                    case "6":
                        ViewAllDeveloperTeams();
                        break;
                    case "7":
                        ViewIndividualTeam();
                        break;
                    case "8":
                        AddDeveloperToTeam();
                        break;
                    case "9":
                        AddMultipleDevelopersToTeam();
                        break;
                    case "10":
                        RemoveDeveloperFromTeam();
                        break;
                    case "11":
                        RemoveMultipleDevelopersFromTeam();
                        break;
                    case "12":
                        ViewDevelopersWithoutPluralsight();
                        break;
                    case "13":
                        Console.WriteLine("Goodbye");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.ReadLine();
                Console.Clear();
            }
        }

        private void ViewDevelopersWithoutPluralsight()
        {
            Console.Clear();
            List<Developer> developers = _developerRepository.GetDevelopersWithoutPSL();
            foreach (var developer in developers)
            {
                Console.WriteLine($"{developer.Name}\n" +
                    $"{developer.IdNumber}\n" +
                    $"{developer.HasPluralsight}");
            }
        }

        private void RemoveMultipleDevelopersFromTeam()
        {
            Console.Clear();

            Console.WriteLine("Enter the Dev Team Id Number.");
            int teamId = int.Parse(Console.ReadLine());
            DevTeam devTeam = _devTeamRepository.GetDevTeamsById(teamId);
            
            List<Developer> developersToRemove = new List<Developer>();

            bool hasGatheredDevelopers = false;
            while (hasGatheredDevelopers==false)
            {
                Console.WriteLine("Do you have a developer you want to remove? y/n");
                string input = Console.ReadLine();
                if (input =="y" || input =="Y")
                {
                    Console.WriteLine("Enter the Developer Id you wish to remove from the team.");
                    int developerId = int.Parse(Console.ReadLine());
                    Developer developer = _developerRepository.GetDeveloperById(developerId);
                    developersToRemove.Add(developer);
                    Console.Clear();
                }
                if (input == "n" || input == "N")
                {
                    _devTeamRepository.RemoveMultipleDevToTeam(teamId, developersToRemove);
                    hasGatheredDevelopers = true;
                }
               

                
            }
        }

        private void AddMultipleDevelopersToTeam()
        {
            Console.Clear();

            Console.WriteLine("Enter the Dev Team Id Number you want to add to.");
            int teamId = int.Parse(Console.ReadLine());

            List<Developer> developersToAdd = new List<Developer>();
            bool hasFilledPositions = false;

            while (hasFilledPositions==false)
            {
                Console.WriteLine("Do you have anymore Developers to add to the team y/n");
                string input = Console.ReadLine();

                if (input =="Y" || input =="y")
                {
                    Console.Clear();
                    Developer newDeveloper = new Developer();

                    Console.WriteLine("Enter the Name of the Developer.");
                    newDeveloper.Name = Console.ReadLine();

                    Console.WriteLine("Enter the ID Number of the Developer");
                    newDeveloper.IdNumber = int.Parse(Console.ReadLine());

                    Console.WriteLine("Does the Developer has Pluralsight? (y/n)");
                    string hasPluralSight = Console.ReadLine();

                    if (hasPluralSight == "y")
                    {
                        newDeveloper.HasPluralsight = true;
                    }
                    else
                    {
                        newDeveloper.HasPluralsight = false;
                    }
                    _developerRepository.AddDeveloperToRepo(newDeveloper);
                    developersToAdd.Add(newDeveloper);

                }
                if (input=="N" || input=="n")
                {
                    _devTeamRepository.AddMultipleDevToTeam(teamId, developersToAdd);
                    hasFilledPositions = true;
                }
            }


           

        }

        private void RemoveDeveloperFromTeam()
        {
            Console.Clear();
            
            Console.WriteLine("Enter the Dev Team Id Number.");
            int teamId = int.Parse(Console.ReadLine());
            DevTeam devTeam = _devTeamRepository.GetDevTeamsById(teamId);
            
            Console.WriteLine("Enter the Developer Id you wish to remove from the team.");
            int developerId = int.Parse(Console.ReadLine());
            Developer developer = _developerRepository.GetDeveloperById(developerId);
            
            bool wasSuccessful = _devTeamRepository.RemoveDevFromTeam(teamId, developer);
                
            if (wasSuccessful == true)
            {
                
                Console.WriteLine("The Developer has been successfully removed."); 
            }
            else
            {
                Console.WriteLine("The Developer could not be removed");
            }
            
        }

        private void AddDeveloperToTeam()
        {
           Console.Clear();
            ViewAllDeveloperTeams();

            Console.WriteLine("Enter the Dev Team Id Number you want to add to.");
            int teamId = int.Parse(Console.ReadLine());
           DevTeam dev = _devTeamRepository.GetDevTeamsById(teamId);


            Console.WriteLine("Enter the Id Number of the Developer that needs added.");
            int developerId = int.Parse(Console.ReadLine());

            Developer developer = _developerRepository.GetDeveloperById(developerId);
            bool wasAdded =_devTeamRepository.AddDevToTeam(teamId, developer);
           
            

            if (wasAdded == true)
            {
                Console.WriteLine("The Developer has successfully been added.");
            }
            else
            {
                Console.WriteLine("The Developer could not be added.");
            }
            
        }

        private void ViewIndividualTeam()
        {
            Console.Clear();
            Console.WriteLine("Enter Dev Team Id Number.");
            int input = int.Parse(Console.ReadLine());
            DevTeam team = _devTeamRepository.GetDevTeamsById(input);

            if (team!=null)
            {
                foreach (var developer in team.Developers)
                {
                    Console.WriteLine($"Name{developer.Name}\n" +
                      $"Team ID{team.TeamId}\n" +
                      $"Id Number{developer.IdNumber}\n" +
                      $"Pluralsight{developer.HasPluralsight}");
                }
            }
        }

        private void ViewAllDeveloperTeams()
        {
            Console.Clear();
            //I'm grabbing all of the Development Teams from the Development Team Repo
            List<DevTeam> devTeams = _devTeamRepository.GetDevTeams();
            foreach (DevTeam team in devTeams)
            {
                foreach (Developer developer in team.Developers)
                {
                    Console.WriteLine($"Name{developer.Name}\n" +
                        $"Team ID{team.TeamId}\n" +
                        $"Id Number{developer.IdNumber}\n" +
                        $"Pluralsight{developer.HasPluralsight}");
                }
            }
        }

        private void DeleteExistingDeveloper()
        {
            ViewAllDevelopers();

            Console.WriteLine("\n Enter the ID Number of the Developer that needs to be deleted.");
            
            int input = int.Parse(Console.ReadLine());
            bool isSuccessful = _developerRepository.RemoveDeveloper(input);

            if (isSuccessful== true)
            {
                Console.WriteLine("The Developer was succefully deleted.");
            }
            else
            {
                Console.WriteLine("The Developer could not be deleted.");
            }
        }

        private void UpdateExistingDeveloper()
        {
            ViewAllDevelopers();

            Console.WriteLine("Enter the ID Number of the Developer to update.");

            int oldIdNumber = int.Parse(Console.ReadLine());

            Developer newDeveloper = new Developer();

            Console.WriteLine("Enter the Name for the Developer.");
            newDeveloper.Name = Console.ReadLine();

            Console.WriteLine("Enter the ID Number for the Developer.");
            newDeveloper.IdNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Does the Developer have Pluralsight? (y/n)");
            string hasPluralSight = Console.ReadLine();

            if (hasPluralSight == "y")
            {
                newDeveloper.HasPluralsight = true;
            }
            else
            {
                newDeveloper.HasPluralsight = false;
            }
            bool wasUpdated = _developerRepository.UpdateExistingDeveloper(oldIdNumber, newDeveloper);
           
            if (wasUpdated)
            {
                Console.WriteLine("Developer successfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update Developer.");
            }
        }

        private void ViewDeveloperById()
        {
            Console.Clear();
            Console.WriteLine("Enter the ID Number of the Developer.");

            int idNumber = int.Parse (Console.ReadLine());
            Developer developer = _developerRepository.GetDeveloperById(idNumber);

            if (developer != null)
            {
                Console.WriteLine($"Name: {developer.Name}\n" +
                    $"Id Number: {developer.IdNumber}\n" +
                    $"Has Pluralsight: {developer.HasPluralsight}");
            }
            else
            {
                Console.WriteLine("No Developer found.");
            }
        }

        private void ViewAllDevelopers()
        {
            Console.Clear();

            List<Developer> developers = _developerRepository.GetDevelopers();

            foreach (Developer developer in developers)
            {
                Console.WriteLine($"Name: {developer.Name}\n" +
                    $"Id Number: {developer.IdNumber}\n" +
                    $"Has Pluralsight: {developer.HasPluralsight}");
            }

        }

        private void CreateNewDeveloper()
        {
            Console.Clear();
            Developer newDeveloper = new Developer();

            Console.WriteLine("Enter the Name of the Developer.");
            newDeveloper.Name = Console.ReadLine();

            Console.WriteLine("Enter the ID Number of the Developer");
            newDeveloper.IdNumber = int.Parse( Console.ReadLine());

            Console.WriteLine("Does the Developer has Pluralsight? (y/n)");
            string hasPluralSight = Console.ReadLine();

            if(hasPluralSight == "y")
            {
                newDeveloper.HasPluralsight = true;
            }
            else
            {
                newDeveloper.HasPluralsight = false;
            }
            _developerRepository.AddDeveloperToRepo(newDeveloper);
            
        }
        private void SeedDeveloperList()
        {
            Developer George = new Developer("George", 1, true);
            Developer Walter = new Developer("Walter", 2, false);
            Developer Nancy = new Developer("Nancy", 3, true);

            _developerRepository.AddDeveloperToRepo(George);
            _developerRepository.AddDeveloperToRepo(Walter);
            _developerRepository.AddDeveloperToRepo(Nancy);

            DevTeam team1 = new DevTeam(1, new List<Developer> { George, Walter });
            DevTeam team2 = new DevTeam(2, new List<Developer> { Nancy});

            _devTeamRepository.AddTeamToRepo(team1);
            _devTeamRepository.AddTeamToRepo(team2);
        }
    }

}
