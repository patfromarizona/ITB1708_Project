using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Soft.Data
{
    public class TeamWork
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        [Display(Name = "Team Size")]
        public int? TeamSize { get; set; }
        public DateTime? Deadline { get; set; }
        public bool? Done { get; set; }

    }
}
