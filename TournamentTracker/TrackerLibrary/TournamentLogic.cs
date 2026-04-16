using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TrackerLibrary.Models;

namespace TrackerLibrary
{
    public static class TournamentLogic
    {
        // Create matchups
        // Order our list of teams randomly
        // Check if list is big enough, if not add in byes (to bypass a matchup for some players)
        // Create our first round of matchups
        // Create every round after that. Each round has half the number of matchups as the previous round

        public static void CreateRounds(TournamentModel model)
        {
            List<TeamModel> randomisedTeams = RandomiseTeamOrder(model.EnteredTeams);
            int rounds = FindNumberOfRounds(randomisedTeams.Count);
            int byes = NumberOfByes(rounds, randomisedTeams.Count);

            model.Rounds.Add(CreateFirstRound(byes, randomisedTeams));

            CreateSubsequentRounds(model, rounds);
        }

        private static void CreateSubsequentRounds(TournamentModel model, int rounds)
        {
            int round = 2;
            List<MatchupModel> previousRound = model.Rounds[0]; // Grabs the first round of matchups from the tournament model
            List<MatchupModel> currentRound = new List<MatchupModel>();
            MatchupModel currentMatchup = new MatchupModel();

            while (round <= rounds)
            {
                foreach (MatchupModel match in previousRound)
                {
                    currentMatchup.Entries.Add(new MatchupEntryModel { ParentMatchup = match });

                    // When we have 2 entries in the matchup we add it to the current round and reset
                    if (currentMatchup.Entries.Count > 1) 
                    {
                        currentMatchup.MatchupRound = round;
                        currentRound.Add(currentMatchup);
                        currentMatchup = new MatchupModel();
                    }
                }

                model.Rounds.Add(currentRound);
                previousRound = currentRound;

                currentRound = new List<MatchupModel>();
                round += 1;
            }
        }

        private static List<MatchupModel> CreateFirstRound(int byes, List<TeamModel> teams)
        {
            List<MatchupModel> output = new List<MatchupModel>();
            MatchupModel curr = new MatchupModel();

            foreach (TeamModel team in teams)
            {
                curr.Entries.Add(new MatchupEntryModel {  TeamCompeting = team });

                if (byes > 0 || curr.Entries.Count > 1)
                {
                    curr.MatchupRound = 1;
                    output.Add(curr);
                    curr = new MatchupModel();

                    if (byes > 0)
                    {
                        byes -= 1;
                    }
                }
            }

            return output;
        }
        private static int NumberOfByes(int rounds, int numberOfTeams)
        {
            int output = 0;
            int totalTeams = 1;

            for (int i = 1; i <= rounds; i++)
            {
                totalTeams *= 2;
            }

            output = totalTeams - numberOfTeams;
            return output;
        }
        private static int FindNumberOfRounds(int teamCount)
        {
            int output = 1;
            int val = 2;

            while (val < teamCount)
            {
                output += 1;
                val *= 2;
            }

            return output;
        }

        private static List<TeamModel> RandomiseTeamOrder(List<TeamModel> teams)
        {
            // Pseudo/simple random solution
            return teams.OrderBy(t => Guid.NewGuid()).ToList();
        }
    }
}
