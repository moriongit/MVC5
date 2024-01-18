using System.ComponentModel.DataAnnotations;

namespace MVC5.Models
{
    public class Team
    {
        public int Id { get; set; }
        [MaxLength(32),MinLength(3)]
        public string Name { get; set; }
        [MaxLength(32), MinLength(3)]
        public string Description { get; set; }
        public string ImgUrl { get; set; }
    }
}
