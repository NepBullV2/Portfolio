namespace API.Database
{
    public class Context : DbContext
    {
        public Context() { }
        public Context(DbContextOptions<Context> options) : base(options) { }

        //Add new databases to context file here.
        public DbSet<Locations> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            ///<summary>
            /// Create one modelbuilder for each new Database added to this context file.
            /// </summary>

            modelbuilder.Entity<Locations>().HasData(
                new Locations
                {
                    ID = 1,
                    Postal = 1111,
                    City = "CityName Here"
                }
                );
        }
    }
}
