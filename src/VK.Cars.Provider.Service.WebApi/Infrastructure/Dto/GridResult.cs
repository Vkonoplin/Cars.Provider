using System.Collections.Generic;

namespace VK.Cars.Provider.Service.WebApi.Infrastructure.Dto
{
    public class GridResult<T>
        where T : class
    {
        public GridResult(IList<T> collection, GridOptions options)
        {
            Result = collection;
            GridOptions = options;
        }

        public IList<T> Result { get; }

        public GridOptions GridOptions { get;  }
    }
}
