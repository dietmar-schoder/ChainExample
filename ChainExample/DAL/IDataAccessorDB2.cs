using ChainExample.Models;

namespace ChainExample.DAL
{
    public interface IDataAccessorDB2
    {
        Task<bool> InsertAsync(AnyDataObject anyDataObject);

        Task<bool> DeleteAsync(Guid id);
    }
}
