

namespace Utils.Models
{
    public class Customers
    {
        public Customers() { }
        public Customers(int customer_id,string customer_name, string country, string city, string region, string postal_code)
        {
            Customer_id = customer_id;
            Customer_name = customer_name;
            Country = country;
            City = city;
            Region = region;
            Postal_code = postal_code;
        }
        public int Customer_id { get; set; }
        public string Customer_name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Postal_code { get; set; }
        public override string ToString()
        {
            return $"Customer name: {Customer_name}, Country: {Country},City: {City},Region: {Region},Postal_code: {Postal_code} ";
        }
    }
}
