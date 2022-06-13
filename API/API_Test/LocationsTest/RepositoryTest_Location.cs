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

        [Fact]
        public async Task Get_By_ID_Should_Return_Null_When_No_Location_Found()
        {
            await _context.Database.EnsureDeletedAsync();

            var result = await _sut.GetByID(1);
            Null(result);
        }

        [Fact]
        public async Task Create_New_Location_Should_Add_New_Location_To_Database()
        {
            Intel();

            Locations newLocation = new Locations
            {
                Postal = 3333,
                City = "City Name 3 Here"
            };
            await _context.SaveChangesAsync();

            var result = await _sut.AddNewLocation(newLocation);

            NotNull(result);
            IsType<Locations>(result);
            Equal(3, result.ID);
        }

        [Fact]
        public async Task Create_New_Location_Should_Return_Error_When_Already_Exists()
        {
            await _context.Database.EnsureDeletedAsync();
            Locations ExistingLocation = new Locations
            {
                ID = 1,
                Postal = 1111,
                City = "City Name 1 Here"
            };
            _context.Locations.Add(ExistingLocation);
            await _context.SaveChangesAsync();

            Func<Task> action = async () => await _sut.AddNewLocation(ExistingLocation);

            var result = await ThrowsAsync<ArgumentException>(action);
            Contains("An item with the same key has already been added", result.Message);
        }

        [Fact]
        public async Task Update_Location_Should_Update_Location_Data_With_New_Values()
        {
            Intel();
            Locations UpdatedLocation = new Locations
            {
                ID = 1,
                Postal = 1234,
                City = "New City Name 1 Here"
            };

            var result = await _sut.UpdateLocation(1, UpdatedLocation);

            NotNull(result);
            IsType<Locations>(result);
            Equal(UpdatedLocation.Postal, result.Postal);
            Equal(UpdatedLocation.City, result.City);
        }

        [Fact]
        public async Task Update_Location_Should_Return_Error_When_Existing_Location_Not_Found()
        {
            await _context.Database.EnsureDeletedAsync();

            Locations UpdatedLocation = new Locations
            {
                ID = 1,
                Postal = 1111,
                City = "Return error Not Found"
            };
            var result = await _sut.UpdateLocation(1, UpdatedLocation);

            Null(result);
        }

        [Fact]
        public async Task Delete_Location_Should_Remove_Location_From_Database()
        {
            Intel();

            var result = await _sut.DeleteLocation(1);
            var usedToEmptyListPleaseIgnore = await _sut.DeleteLocation(2);
            var list = await _sut.GetAll();

            NotNull(result);
            IsType<Locations>(result);
            Equal(1, result.ID);
                
            Empty(list);
        }

        [Fact]
        public async Task Delete_Location_Should_Return_Error_When_Location_Not_Found()
        {
            await _context.Database.EnsureDeletedAsync();
            var result = await _sut.DeleteLocation(1);
            Null(result);
        }
    }
}
