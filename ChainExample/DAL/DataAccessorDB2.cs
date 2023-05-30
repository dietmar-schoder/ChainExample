using ChainExample.Models;

namespace ChainExample.DAL
{
    public class DataAccessorDB2 : IDataAccessorDB2
    {
        public Task<bool> DeleteAsync(Guid id) => Task.FromResult(true);

        public Task<bool> InsertAsync(AnyDataObject anyDataObject) => Task.FromResult(true);
    }
}
