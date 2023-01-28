using InteriorHubServer.Domain.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteriorHubServer.Services.Impelementations
{
    public abstract class BaseEntityService<T> where T : class
    {
        protected void PaginateCollection(ref IQueryable<T> values, PagingParameter pagingParameters)
        {
            values = values
                .Skip((pagingParameters.PageNumber - 1) * pagingParameters.PageSize)
                .Take(pagingParameters.PageSize);
        }
    }
}
