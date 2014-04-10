
namespace Domain.Models
{
    public class Jewelry
    {
        public virtual int Id { get; protected set; } 
        public virtual string Name { get; set; }
        public virtual string ImageFileName { get; set; }
        public virtual int Quantity { get; set; }
    }
}
