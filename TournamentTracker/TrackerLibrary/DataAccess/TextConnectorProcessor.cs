using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Reflection;
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
        public static List<TournamentModel> ConvertToTournamentModels(
            this List<string> lines,
            string teamFileName,
            string peopleFileName,
            string prizeFileName)
        {
            // id = 0
            // TournamentName = 1
            // EntryFee = 2
            // EnteredTeams = 3
            // Prizes = 4
            // Rounds = 5
            // Data saved into this format per line:
            // id,TournamentNaame,EntryFee,(id|id|id - Entered Teams), (id|id|id - Prizes), (Rounds - id^id^id|id^id^id|id^id^id)
            List<TournamentModel> output = new List<TournamentModel>();
            List<TeamModel> teams = teamFileName.FullFilePath().LoadFile().ConvertToTeamModels(peopleFileName);
            List<PrizeModel> prizes = prizeFileName.FullFilePath().LoadFile().ConvertToPrizeModels();


            foreach (string line in lines)
            {
                // First split by comma, each "field" is divided by a comma
                string[] cols = line.Split(",");

                TournamentModel tm = new TournamentModel();
                tm.TournamentId = int.Parse(cols[0]);
                tm.TournamentName = cols[1];
                tm.EntryFee = decimal.Parse(cols[2]);

                string[] teamIds = cols[3].Split('|');
                foreach (string id in teamIds)
                {
                    tm.EnteredTeams.Add(teams.Where(x => x.TeamId == int.Parse(id)).First());
                }

                string[] prizeIds = cols[4].Split('|');
                foreach(string id in prizeIds)
                {
                    tm.Prizes.Add(prizes.Where(x => x.PrizeId == int.Parse(id)).First());
                }

                // TODO - Capture Rounds Information

                output.Add(tm);
            }
            return output;
        }
        // List Convertor Methods
        private static string ConvertRoundListToString(List<List<MatchupModel>> rounds)
        {
            string output = "";
            // Return an empty string if there are no people in the input List, avoiding a bug with the Substring method later
            if (rounds.Count == 0)
            {
                return "";
            }
            // Loop through the list of people and create a string of their IDs separated by '|' characters
            foreach (List<MatchupModel> r in rounds)
            {
                output += $"{ ConvertMatchupListToString(r) }|";
            }
            output = output.Substring(0, output.Length - 1);

            return output;
        }
        private static string ConvertMatchupListToString(List<MatchupModel> matchups)
        {
            string output = "";
            // Return an empty string if there are no people in the input List, avoiding a bug with the Substring method later
            if (matchups.Count == 0)
            {
                return "";
            }
            // Loop through the list of people and create a string of their IDs separated by '|' characters
            foreach (MatchupModel m in matchups)
            {
                output += $"{m.MatchupId}^";
            }
            output = output.Substring(0, output.Length - 1);

            return output;
        }
        private static string ConvertMatchupEntryListListToString(List<MatchupEntryModel> entries)
        {
            string output = "";
            // Return an empty string if there are no people in the input List, avoiding a bug with the Substring method later
            if (entries.Count == 0)
            {
                return "";
            }
            // Loop through the list of people and create a string of their IDs separated by '|' characters
            foreach (MatchupEntryModel e in entries)
            {
                output += $"{e.MatchupEntryId}|";
            }
            output = output.Substring(0, output.Length - 1);

            return output;
        }
        private static string ConvertPrizeListToString(List<PrizeModel> prizes)
        {
            string output = "";
            // Return an empty string if there are no people in the input List, avoiding a bug with the Substring method later
            if (prizes.Count == 0)
            {
                return "";
            }
            // Loop through the list of people and create a string of their IDs separated by '|' characters
            foreach (PrizeModel p in prizes)
            {
                output += $"{p.PrizeId}|";
            }
            output = output.Substring(0, output.Length - 1);

            return output;
        }
        private static string ConvertTeamListToString(List<TeamModel> teams)
        {
            string output = "";
            // Return an empty string if there are no people in the input List, avoiding a bug with the Substring method later
            if (teams.Count == 0)
            {
                return "";
            }
            // Loop through the list of people and create a string of their IDs separated by '|' characters
            foreach (TeamModel t in teams)
            {
                output += $"{t.TeamId}|";
            }
            output = output.Substring(0, output.Length - 1);

            return output;
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
                output += $"{p.PersonId}|";
            }
            output = output.Substring(0, output.Length - 1);

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
        public static void SaveRoundsToFile(this TournamentModel model, string matchupFile, string matchupEntryFile)
        {
            // Loop through each round
            // Loop through each Matchup
            // Get the id for the new matchup and save the record
            // Loop through each Entry, get the id, and save

            foreach (List<MatchupModel> round in model.Rounds)
            {
                foreach (MatchupModel matchup in round)
                {
                    // Load all of the matchups from file
                    // Get the top ID and add one
                    // Store the ID
                    // Save the matchup record
                    matchup.SaveMatchupToFile(matchupFile, matchupEntryFile);
                }
            }
        }
        public static List<MatchupEntryModel> ConvertToMatchupEntryModels(this List<string> lines)
        {
            // MatchupEntryId=0, TeamCompeting=1, Score=2, ParentMatchup=3
            List<MatchupEntryModel> output = new List<MatchupEntryModel>();
            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                MatchupEntryModel me = new MatchupEntryModel();
                me.MatchupEntryId = int.Parse(cols[0]);
                me.TeamCompeting = LookupTeamById(int.Parse(cols[1]));
                me.Score = double.Parse(cols[2]);

                int parentId = 0;
                if (int.TryParse(cols[3], out parentId))
                {
                    me.ParentMatchup = LookupMatchupById(int.Parse(cols[3]));
                }
                else
                {
                    me.ParentMatchup = null;
                }
                output.Add(me);
            }
            return output;
        }
        private static List<MatchupEntryModel> ConvertStringToMatchupEntryModels(string input)
        {
            string[] ids = input.Split('|');
            List<MatchupEntryModel> output = new List<MatchupEntryModel>();
            List<MatchupEntryModel> entries = GlobalConfig.MatchupEntryFile.FullFilePath().LoadFile().ConvertToMatchupEntryModels();

            foreach (string id in ids)
            {
                output.Add(entries.Where(x => x.MatchupEntryId == int.Parse(id)).First());
            }
            return output;
        }
        private static TeamModel LookupTeamById(int id)
        {
            List<TeamModel> teams = GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModels(GlobalConfig.PeopleFile);

            return teams.Where(x => x.TeamId == id).First();
        }
        private static MatchupModel LookupMatchupById(int id)
        {
            List<MatchupModel> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModels();

            return matchups.Where(x => x.MatchupId == id).First();
        }
        public static List<MatchupModel> ConvertToMatchupModels(this List<string> lines)
        {
            // matchupid=0, etnries=1(pipe delimited by id), winner=2, matchupRound=3
            List<MatchupModel> output = new List<MatchupModel>();
            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                MatchupModel p = new MatchupModel();
                p.MatchupId = int.Parse(cols[0]);
                p.Entries = ConvertStringToMatchupEntryModels(cols[1]);
                p.Winner = LookupTeamById(int.Parse(cols[2]));
                p.MatchupRound = int.Parse(cols[3]);
                output.Add(p);
            }
            return output;
        }

        public static void SaveMatchupToFile(this MatchupModel matchup, string matchupFile, string matchupEntryFile)
        {
            //List<TournamentModel> tournaments = TournamentFile
            //    .FullFilePath()
            //    .LoadFile()
            //    .ConvertToTournamentModels(TeamFile, PeopleFile, PrizesFile);

            List<MatchupModel> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModels();

            int currentId = 1;

            if (matchups.Count > 0)
            {
                currentId = matchups.OrderByDescending(x => x.MatchupId).First().MatchupId + 1;
            }

            matchup.MatchupId = currentId;

            foreach (MatchupEntryModel entry in matchup.Entries)
            {
                entry.SaveEntryToFile(matchupEntryFile);
            }

            // Save matchup entry File
            List<string> lines = new List<string>();

            // matchupid=0, etnries=1(pipe delimited by id), winner=2, matchupRound=3
            foreach (MatchupModel m in matchups)
            {
                string winner = "";
                if (m.Winner != null)
                {
                    winner = m.Winner.TeamId.ToString();
                }
                lines.Add($"{m.MatchupId},{ConvertMatchupEntryListListToString(m.Entries)},{winner},{m.MatchupRound}");
            }

            File.WriteAllLines(GlobalConfig.MatchupFile.FullFilePath(), lines);
        }
        public static void SaveEntryToFile(this MatchupEntryModel entry, string matchupEntryFile)
        {
            List<MatchupEntryModel> entries = GlobalConfig.MatchupEntryFile.FullFilePath().LoadFile().ConvertToMatchupEntryModels();

            int currentId = 1;

            if (entries.Count > 0)
            {
                currentId = entries.OrderByDescending(x => x.MatchupEntryId).First().MatchupEntryId + 1;
            }

            entry.MatchupEntryId = currentId;
            entries.Add(entry);

            // Save Matchup file
            List<string> lines = new List<string>();
            
            // MatchupEntryId=0, TeamCompeting=1, Score=2, ParentMatchup=3
            foreach (MatchupEntryModel e in entries)
            {
                string parent = "";
                if (e.ParentMatchup != null)
                {
                    parent = e.ParentMatchup.MatchupId.ToString();
                }
                lines.Add($"{e.MatchupEntryId},{e.TeamCompeting.TeamId},{e.Score},{ parent }");
            }

            File.WriteAllLines(GlobalConfig.MatchupEntryFile.FullFilePath(), lines);

        }
        public static void SaveToTournamentFile(this List<TournamentModel> models, string fileName)
        {
            // id = 0
            // TournamentName = 1
            // EntryFee = 2
            // EnteredTeams = 3
            // Prizes = 4
            // Rounds = 5

            List<string> lines = new List<string>();

            foreach (TournamentModel tm in models)
            {
                lines.Add($@"{ tm.TournamentId },
                        { tm.TournamentName },
                        { tm.EntryFee },
                        { ConvertTeamListToString(tm.EnteredTeams) },
                        { ConvertPrizeListToString(tm.Prizes) },
                        { ConvertRoundListToString(tm.Rounds) }");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }
    }
}
