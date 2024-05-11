using Saxmay.Entities.Base;

namespace Saxmay.Entities
{
    public class Activity: EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public bool IsActive { get; set; }
    }
}
