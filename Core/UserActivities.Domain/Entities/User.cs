using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserActivities.Domain.Entities.Common;

namespace UserActivities.Domain.Entities
{
    public class User : BaseEntity
    {
        public int UserId { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime JoinDate { get; set; }
        public virtual ICollection<Activity> Activities { get; set; } 
    }

}
