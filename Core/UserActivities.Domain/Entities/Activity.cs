using UserActivities.Domain.Entities.Common;

namespace UserActivities.Domain.Entities
{
    public class Activity : BaseEntity
    {
        public int ActivityId { get; set; }
        public int UserId { get; set; }        
        public int ActivityType { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime ActivityDate { get; set; }
        public virtual User User { get; set; } 
    }

}
