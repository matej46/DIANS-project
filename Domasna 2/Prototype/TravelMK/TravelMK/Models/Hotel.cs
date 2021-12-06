namespace TravelMK.Models
{
    public class Hotel
    {
        public int ID { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public int stars { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }

        public Hotel() { }
    }
}
