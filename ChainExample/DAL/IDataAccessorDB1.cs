using ChainExample.Models;

namespace ChainExample.DAL
{
    public interface IDataAccessorDB1
    {
        Task<bool> UpdateAsync(AnyDataObject anyDataObject);
    }
}
