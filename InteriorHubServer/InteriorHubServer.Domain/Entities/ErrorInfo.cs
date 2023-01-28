using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteriorHubServer.Domain.Entities
{
    public class ErrorInfo
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime ErrorTime { get; set; }
    }
}
