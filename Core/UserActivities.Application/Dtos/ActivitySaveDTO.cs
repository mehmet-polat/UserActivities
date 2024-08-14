using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserActivities.Application.Enums;
using UserActivities.Domain.Entities;

namespace UserActivities.Application.Dtos
{
    public class ActivitySaveDTO
    {
        public int UserId { get; set; }
        public ActivityTypes ActivityType { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime ActivityDate { get; set; }
    }

}
