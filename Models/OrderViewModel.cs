using ChushkaAssignment.Data.Enums;
using ChushkaAssignment.Data.Models;

namespace ChushkaAssignment.Models
{
    public class OrderViewModel
    {
        public string Id { get; set; }
        public virtual AppUser Customer { get; set; }
        public virtual Product Product { get; set; }
        public DateTime OrderedOn { get; set; }
    }
}
