using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteriorHubServer.Domain.Entities
{
    public class NotificationSettings
    {
        public long Id { get; set; }
        public bool Email { get; set; }
    }
}
