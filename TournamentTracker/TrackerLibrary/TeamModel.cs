using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary
{
    /// <summary>
    /// Represents a team that consists of multiple members and has a team name
    /// </summary>
    public class TeamModel
    {
        /// <summary>
        /// Represents a list of team members that are part of this team. 
        /// Each member is represented by a PersonModel.
        /// </summary>
        public List<PersonModel> TeamMembers { get; set; } = new List<PersonModel>();

        /// <summary>
        /// Represents the name of the team.
        /// </summary>
        public string TeamName { get; set; }
    }
}
