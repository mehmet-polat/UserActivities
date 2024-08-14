using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserActivities.Domain.Entities;

namespace UserActivities.Application.ViewModels
{
    public class ActivityViewModel
    {
        public int ActivityId { get; set; }
        public int UserId { get; set; }
        public int ActivityType { get; set; }
        public string ActivityTypeDescription { get; set; }=string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime ActivityDate { get; set; }
        public string User { get; set; } = string.Empty;
    }
}
