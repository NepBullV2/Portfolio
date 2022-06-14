namespace API.Interface
{
    public class Interface
    {
        //Review the whole CRUD system for all entities here.
        public interface Repository_Interface_Locations
        {
            Task<List<Locations>> GetAll();
            Task<Locations> GetByID(int id);
            Task<Locations> AddNewLocation(Locations location);
            Task<Locations> UpdateLocation(int id, Locations NewData);
            Task<Locations> DeleteLocation(int id);
        }
        public interface Service_Interface_Locations
        {
            Task<List<Response_Location>> GetAll();
            Task<Response_Location> GetByID(int id);
            Task<Response_Location> AddNewLocation(Locations location);
            Task<Response_Location> UpdateLocation(int id, Locations NewData);
            Task<bool> DeleteLocation(int id);
        }
    }
}
