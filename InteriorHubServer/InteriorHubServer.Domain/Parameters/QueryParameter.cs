using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteriorHubServer.Domain.Parameters
{
    public class QueryParameter : PagingParameter
    {
        public string? OrderBy { get; set; } = default; //virtual ?
        public string? Fields { get; set; } = default; //virtual ?
    }
}
