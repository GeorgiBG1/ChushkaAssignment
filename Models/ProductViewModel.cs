
using ChushkaAssignment.Data.Enums;

namespace ChushkaAssignment.Models
{
    public class ProductViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        //public virtual int ProductType { get; set; } = 1;
        //public string[] ProductTypes = new[] { "Food",
        //"Domestic", "Health", "Cosmetic", "Other"};
        public ProductType ProductType { get; set; }
    }
}
