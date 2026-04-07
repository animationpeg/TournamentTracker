using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Text;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess.TextHelpers
{
    public static class TextConnectorProcessor
    {
        // Create full file path from file name and file path
        public static string FullFilePath(this string fileName)
        {
            return $"{GlobalConfig.FilePath}\\{fileName}";
        }

        // Load a text file and return the lines as a list of strings
        public static List<string> LoadFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }
            return File.ReadAllLines(file).ToList();
        }

        // Methods for converting Models from loaded .csv files and adding them to program models.
        // Take the list of strings from the loaded files and add the data into a PrizeModel for program data handling
        public static List<PrizeModel> ConvertToPrizeModels(this List<string> lines)
        {
            List<PrizeModel> output = new List<PrizeModel>();
            foreach (string line in lines)
            {
                string[] cols = line.Split(',');
                PrizeModel p = new PrizeModel();
                p.PrizeId = int.Parse(cols[0]);
                p.PlaceNumber = int.Parse(cols[1]);
                p.PlaceName = cols[2];
                p.PrizeAmount = decimal.Parse(cols[3]);
                p.PrizePercentage = double.Parse(cols[4]);
                output.Add(p);
            }
            return output;
        }
        public static List<PersonModel> ConvertToPersonModels(this List<string> lines)
        {
            List<PersonModel> output = new List<PersonModel>();
            foreach(string line in lines)
            {
                string[] cols = line.Split(',');
                PersonModel p = new PersonModel();
                p.PersonId = int.Parse(cols[0]);
                p.FirstName = cols[1];
                p.LastName = cols[2];
                p.EmailAddress = cols[3];
                p.PhoneNumber = cols[4];
                output.Add(p);
            }
            return output;
        }
        public static List<TeamModel> ConvertToTeamModels(this List<string> lines, string peopleFileName)
        {
            // Create text file with this data setup "{TeamId},{TeamName},{PersonId}|{PersonId}|{PersonId}..." with as many
            // PersonId's as necessary, separated by '|' characters to distinguish them from the ',' comma separated entries
            List<TeamModel> output = new List<TeamModel>();
            List<PersonModel> people = peopleFileName.FullFilePath().LoadFile().ConvertToPersonModels();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                TeamModel t = new TeamModel();
                t.TeamId = int.Parse(cols[0]);
                t.TeamName = cols[1];

                string[] personIds = cols[2].Split('|');

                foreach (string id in personIds)
                {
                    t.TeamMembers.Add(people.Where(x => x.PersonId == int.Parse(id)).First());
                }
                output.Add(t);
            }
            return output;
        }

        // Methods for saving Models to files
        public static void SaveToPrizeFile(this List<PrizeModel> models, string fileName)
        {
            List<string> lines = new List<string>();
            foreach (PrizeModel p in models)
            {
                lines.Add($"{ p.PrizeId },{ p.PlaceNumber },{ p.PlaceName },{ p.PrizeAmount },{ p.PrizePercentage }");
            }
            File.WriteAllLines(fileName.FullFilePath(), lines);
        }
        public static void SaveToPeopleFile(this List<PersonModel> models, string filename)
        {
            List <string> lines = new List<string>();
            foreach (PersonModel p in models)
            {
                lines.Add($"{ p.PersonId },{ p.FirstName },{ p.LastName },{ p.EmailAddress },{ p.PhoneNumber }");
            }
            File.WriteAllLines(filename.FullFilePath(), lines);
        }
        public static void SaveToTeamFile(this List<TeamModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (TeamModel t in models)
            {
                lines.Add($"{t.TeamId},{t.TeamName},{ConvertPeopleListToString(t.TeamMembers)}");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }
        private static string ConvertPeopleListToString(List<PersonModel> people)
        {
            string output = "";
            // Return an empty string if there are no people in the input List, avoiding a bug with the Substring method later
            if (people.Count == 0)
            {
                return "";
            }
            // Loop through the list of people and create a string of their IDs separated by '|' characters
            foreach (PersonModel p in people)
            {
                output += $"{p.PersonId }|";
            }
            output = output.Substring(0, output.Length - 1);

            return output;
        }
    }
}
