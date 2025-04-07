using System.Collections.Generic;

namespace Ncfe.CodeTest
{
    public interface IFailoverRepository<T>
    {
        List<FailoverEntry> GetFailOverEntries();
    }
}