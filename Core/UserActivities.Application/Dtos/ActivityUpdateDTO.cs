using UserActivities.Application.Enums;

namespace UserActivities.Application.Dtos
{
    public class ActivityUpdateDTO : ActivitySaveDTO
    {
        public int ActivityId { get; set; }
        public ActivityTypes ActivityType { get; set; }
        public string Description { get; set; } = string.Empty;
    }

}
