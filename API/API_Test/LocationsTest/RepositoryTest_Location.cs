namespace API_Test.LocationsTest
{
    public class RepositoryTest_Location
    {
        private readonly Repository_Location _sut;
        private readonly Context _context;
        private readonly DbContextOptions<Context> _options;

        public RepositoryTest_Location()
        {
            _options = new DbContextOptionsBuilder<Context>().UseInMemoryDatabase(databaseName: "PortfolioDatabase").Options;
            _context = new Context(_options);
            _sut = new Repository_Location(_context);
        }

        public async void Intel()
        {
            await _context.Database.EnsureDeletedAsync();
            _context.Locations.Add(
                new Locations
                {
                    ID = 1,
                    Postal = 1111,
                    City = "City Name Here"
                }
                );
            _context.Locations.Add(
                new Locations
                {
                    ID = 2,
                    Postal = 2222,
                    City = "City Name 2 Here"
                }
                );
            await _context.SaveChangesAsync();
        }


        [Fact]
        public async Task Get_All_Locations_Should_Return_List_Of_Locations()
        {
            Intel();

            var result = await _sut.GetAll();

            NotNull(result);
            IsType<List<Locations>>(result);
            Equal(2, result.Count);
        }

        [Fact]
        public async Task Get_By_ID_Should_Return_One_Location()
        {
            Intel();

            var result = await _sut.GetByID(1);

            NotNull(result);
            IsType<Locations>(result);
            Equal(1, result.ID);
        }
    }
}
