namespace ReserveTaPlace.API
{
    public class AppConfig
    {
        public IConfiguration Configuration { get; set; }
        public AppConfig(IConfiguration config)
        {
            Configuration = config;
            ConnectionString = config.GetConnectionString("RTPSQLServer");
            //RTPSQLServer
            //RTPLocalDb
        }
        public string ConnectionString { get; set; }
    }
}
