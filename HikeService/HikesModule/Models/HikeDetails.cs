

namespace HikeService.HikesModule.Models
{
	public class HikeDetails
	{
		public string Url { get; set; }
		public string Name { get; set; }
		public double RoundTripLength { get; set; }
		public double Elevation { get; set; }
		public LocationDetails Location { get; set; }
	}

    public class LocationDetails
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}