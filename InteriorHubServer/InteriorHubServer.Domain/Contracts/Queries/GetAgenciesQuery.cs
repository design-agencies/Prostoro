using InteriorHubServer.Domain.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteriorHubServer.Domain.Contracts.Queries
{
    public class GetAgenciesQuery : QueryParameter
    {
        public string? Budget { get; set; } = default;
        public string? City { get; set; } = default;
        public bool? Remote { get; set; } = default;
        public string[]? Tags { get; set; }
        public GetAgenciesQuery()
        {
            OrderBy = "CreatedOn"; // TODO add enum?
        }

        public bool HaveFilters => 
            !string.IsNullOrEmpty(Budget) || 
            !string.IsNullOrEmpty(City) || 
            (Remote.HasValue && Remote.Value) ||
            (Tags != null && Tags.Length != 0);
    }
}
