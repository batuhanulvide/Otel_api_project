namespace HotelApiProject.WebUI.Dtos.DashboardDtos.SocialMedia
{
    public class LinkedinFollowersDto
    {
        public Data data { get; set; }
        public class Data
        {
            public int follower_count { get; set; }

        }
    }
}
