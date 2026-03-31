using Microsoft.Extensions.Configuration;

using TrackerLibrary.DataAccess;

namespace TrackerUI
{
    internal static class Program
    {
        public static IConfiguration Configuration { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Build the configuration from the appsettings.json file
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Get the connection string from the configuration
            string connectionString = Configuration.GetConnectionString("TournamentTracker");
            // Pass the connection string to the GlobalConfig class to make it available throughout the application
            TrackerLibrary.GlobalConfig.ConnectionString = connectionString;

            string relativePath = Configuration["FilePaths:Base"];
            string fullPath = Path.Combine(AppContext.BaseDirectory, relativePath);

            // Set the file path for the text file storage, by calling the method in the GlobalConfig class
            TrackerLibrary.GlobalConfig.SetFilePath(fullPath);

            // Initialise the database connections for the application
            TrackerLibrary.GlobalConfig.InitializeConnections(TrackerLibrary.DatabaseType.TextFile);

            Directory.CreateDirectory(fullPath);

            Application.Run(new CreateTeamForm());
            //Application.Run(new TournamentDashboardForm());
        }
    }
}