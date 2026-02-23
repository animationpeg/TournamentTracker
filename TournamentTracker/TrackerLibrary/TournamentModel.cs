using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary
{
    /// <summary>
    /// Represents a tournament, including its name, entry fee, participating teams, 
    /// prizes, and the structure of rounds and matchups.
    /// </summary>

    public class TournamentModel
    {
        /// <summary>
        /// Represents the name of the tournament.
        /// </summary>
        public string TournamentName { get; set; }

        /// <summary>
        /// Represents the entry fee for participating in the tournament.
        /// </summary>
        public decimal EntryFee { get; set; }

        /// <summary>
        /// Represents the list of teams that have entered the tournament. 
        /// Each team is represented by a TeamModel.
        /// </summary>
        public List<TeamModel> EnteredTeams { get; set; } = new List<TeamModel>();

        /// <summary>
        /// Represents the list of prizes that can be won in the tournament. 
        /// Each prize is represented by a PrizeModel.
        /// </summary>
        public List<PrizeModel> Prizes { get; set; } = new List<PrizeModel>();

        /// <summary>
        /// Represents a list of rounds in the tournament, where each round is a list of matchups.
        /// </summary>
        public List<List<MatchupModel>> Rounds { get; set; } = new List<List<MatchupModel>>();
    }
}
