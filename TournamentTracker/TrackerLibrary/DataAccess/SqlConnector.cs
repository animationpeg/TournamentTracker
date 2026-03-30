using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TrackerLibrary.Models;
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;

// @PlaceNumber int,
// @PlaceName nvarchar(100),
// @PrizeAmount money,
// @PrizePercentage float,
// @id int = 0 output

namespace TrackerLibrary.DataAccess
{
    public class SqlConnector : IDataConnection
    {
        // Constructor that takes the connection string as a parameter
        public SqlConnector()
        {
            _connectionString = GlobalConfig.ConnectionString;
        }

        /// <summary>
        /// Saves a new prize to the database.
        /// </summary>
        /// <param name="model">The prize information</param>
        /// <returns>The prize information, including the unique identifier.</returns>
        private readonly string _connectionString;


        public PrizeModel CreatePrize(PrizeModel model)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
           {
                var p = new DynamicParameters();
                p.Add("@PlaceNumber", model.PlaceNumber);
                p.Add("@PlaceName", model.PlaceName);
                p.Add("@PrizeAmount", model.PrizeAmount);
                p.Add("@PrizePercentage", model.PrizePercentage);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPrizes_Insert", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@id");

                return model;
            }
        }
    }
    // TODO - Make this class to 
    public class SqlDataAccess
    {
        private readonly string _connectionString;

        public SqlDataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
