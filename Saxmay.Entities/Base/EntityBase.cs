namespace Saxmay.Entities.Base
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = "System";
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; } = "System";
    }
}
