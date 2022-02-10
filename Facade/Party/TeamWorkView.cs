using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamUP.Facade.Party
{
    public class TeamWorkView
    {
        [Required] [DisplayName("ID")] public string TeamWorkId { get; set; }
        [DisplayName("Name")] public string? Name { get; set; }
        [DisplayName("Description")] public string? Description { get; set; }
        [DisplayName("Team Size")] public int? TeamSize { get; set; }
        [DisplayName("Deadline")] public DateTime? Deadline { get; set; }
        [DisplayName("Done")] public bool? Done { get; set; }
        [DisplayName("Overview")] public string? Overview { get; set; }
    }
}
