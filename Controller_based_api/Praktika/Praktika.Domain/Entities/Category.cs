using System.ComponentModel.DataAnnotations;

namespace Praktika.Praktika.Domain.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string? Name { get; set; }

        public string? Description { get; set;}

        public List<Item> Items { get; set;} = new();
    }
}
