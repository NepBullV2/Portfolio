using API.Repositories;

namespace API.Services
{
    public class Service_Locations : Service_Interface_Locations
    {
        private readonly Repositories.Repository_Location _repo;

        public Service_Locations(Repository_Location repo)
        {
            _repo = repo;
        }

        public async Task<Response_Location> AddNewLocation(Locations location)
        {
            Locations newlocation = new Locations
            {
                Postal = location.Postal,
                City = location.City
            };

            newlocation = await _repo.AddNewLocation(newlocation);

            return newlocation == null ? null : new Response_Location
            {
                ID = newlocation.ID,
                Postal = newlocation.Postal,
                City = newlocation.City
            };
        }

        public async Task<bool> DeleteLocation(int id)
        {
            var result = await _repo.DeleteLocation(id);
            return true;
        }

        public async Task<List<Response_Location>> GetAll()
        {
            List<Locations> responseList = await _repo.GetAll();
            return responseList == null ? null : responseList.Select(a => new Response_Location
            {
                ID = a.ID,
                Postal = a.Postal,
                City = a.City
            }).ToList();
        }

        public async Task<Response_Location> GetByID(int id)
        {
            Locations location = await _repo.GetByID(id);
            return location == null ? null : new Response_Location
            {
                ID = location.ID,
                Postal = location.Postal,
                City = location.City
            };
        }

        public async Task<Response_Location> UpdateLocation(int id, Locations NewData)
        {
            Locations location = new Locations
            {
                Postal = NewData.Postal,
                City = NewData.City
            };

            location = await _repo.UpdateLocation(id, location);

            return location == null ? null : new Response_Location
            {
                ID = location.ID,
                Postal = location.Postal,
                City = location.City
            };
        }
    }
}
