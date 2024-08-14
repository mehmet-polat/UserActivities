using UserActivities.Application.Enums;

namespace UserActivities.Application.Dtos
{
    public class ActivityFilterDTO
    {
        public int? UserId { get; set; }
        public ActivityTypes? ActivityType { get; set; }
        public string? Description { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? ActivityTypeId { get; set; }
    }

}
