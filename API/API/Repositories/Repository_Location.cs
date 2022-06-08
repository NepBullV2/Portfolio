namespace API.Repositories
{
    public class Repository_Location : Interface_Locations
    {
        private readonly Context _context;

        public Repository_Location(Context context)
        {
            _context = context;
        }

        public async Task<Locations> AddNewLocation(Locations location)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
            return location;
        }

        public async Task<Locations> DeleteLocation(int id)
        {
            Locations location = await _context.Locations.FirstOrDefaultAsync(a => a.ID == id);
            if (location != null)
            {
                _context.Locations.Remove(location);
                await _context.SaveChangesAsync();
            }
            return location;

        }

        public async Task<List<Locations>> GetAll()
        {
            return await _context.Locations.ToListAsync();
        }

        public async Task<Locations> GetByID(int id)
        {
            return await _context.Locations.FirstOrDefaultAsync(a => a.ID == id);
        }

        public async Task<Locations> UpdateLocation(int id, Locations NewData)
        {
            Locations OldData = await _context.Locations.FirstOrDefaultAsync(a => a.ID == id);
            if (OldData != null)
            {
                //Replace old data with new data here.
                OldData.Postal = NewData.Postal;
                OldData.City = NewData.City;
                await _context.SaveChangesAsync();
            }
            return OldData; //The old data has already been replaced by the time we return.
        }
    }
}
