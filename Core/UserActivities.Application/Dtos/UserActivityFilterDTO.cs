using UserActivities.Application.Enums;

namespace UserActivities.Application.Dtos
{
    public class UserActivityFilterDTO
    {
        
        public ActivityTypes? ActivityType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }

}
