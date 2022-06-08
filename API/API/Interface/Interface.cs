namespace API.Interface
{
    public class Interface
    {
        //Review the whole CRUD system for all entities here.
        public interface Interface_Locations
        {
            Task<List<Locations>> GetAll();
            Task<Locations> GetByID(int id);
            Task<Locations> AddNewLocation(Locations location);
            Task<Locations> UpdateLocation(int id, Locations NewData);
            Task<Locations> DeleteLocation(int id);
        }
    }
}
