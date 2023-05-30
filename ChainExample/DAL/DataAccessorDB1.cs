using ChainExample.Models;

namespace ChainExample.DAL
{
    public class DataAccessorDB1 : IDataAccessorDB1
    {
        public Task<bool> UpdateAsync(AnyDataObject anyDataObject) => Task.FromResult(true);
    }
}
