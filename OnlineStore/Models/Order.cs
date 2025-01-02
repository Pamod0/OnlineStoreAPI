﻿namespace OnlineStore.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } // e.g., "Pending", "Shipped", "Completed"
        public decimal TotalAmount { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }

}
