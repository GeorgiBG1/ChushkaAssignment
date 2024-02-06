using System;

namespace ChushkaAssignment.Data.Models
{
    public class Order
    {
        public Order()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public virtual Product Product { get; set; }
        public virtual AppUser Client { get; set; }
        public DateTime OrderedOn { get; set; }
    }
}
