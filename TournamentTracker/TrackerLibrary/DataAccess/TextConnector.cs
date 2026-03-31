using System;
using System.Collections.Generic;
using System.Text;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextHelpers;

namespace TrackerLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {
        private const string PrizesFile = "PrizeModels.csv";
        private const string PeopleFile = "PersonModels.csv";

        public PrizeModel CreatePrize(PrizeModel model)
        {
            // Load the text file and convert the text to List<PrizeModel>
            List<PrizeModel> prizes = PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();

            // Find the max ID
            int currentId = 1;

            if (prizes.Count > 0)
            {
                currentId = prizes.OrderByDescending(x => x.PrizeId).First().PrizeId + 1;
            }

            model.PrizeId = currentId;

            // Add the new record with the new ID (max + 1)
            prizes.Add(model);

            // Convert the PrizeModel to a Llist<string> and save the Llist<string> to the text file, overwriting it
            prizes.SaveToPrizeFile(PrizesFile);

            return model;
        }

        PersonModel IDataConnection.CreatePerson(PersonModel model)
        {
            List<PersonModel> people = PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();

            int currentId = 1;

            if (people.Count > 0)
            {
                currentId = people.OrderByDescending(x => x.PersonId).First().PersonId + 1;
            }
            
            model.PersonId = currentId;

            people.Add(model);

            people.SaveToPeopleFile(PeopleFile);

            return model;
        }
        // Data Retrieval methods
        public List<PersonModel> GetPerson_All()
        {
            return PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();
        }
    }
}
