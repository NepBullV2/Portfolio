namespace API_Test.LocationsTest
{
    public class Service_Test_Location
    {
        private readonly Service_Locations _sut;
        private readonly Mock<Interface.Repository_Interface_Locations> _LocationRepo = new();

        public Service_Test_Location() => _sut = new Service_Locations((Repository_Location)_LocationRepo.Object);
    }
}
