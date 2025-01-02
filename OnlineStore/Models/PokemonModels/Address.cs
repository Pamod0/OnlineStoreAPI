namespace OnlineStore.Models.PokemonModels
{
    public class Address
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string Type { get; set; } // e.g., "Billing", "Shipping"
    }

}
