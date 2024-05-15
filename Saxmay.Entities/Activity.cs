using Microsoft.EntityFrameworkCore;
using Saxmay.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Saxmay.Entities
{
    public class Activity : EntityBase
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public bool IsActive { get; set; }
    }
}
