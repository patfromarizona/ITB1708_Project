
using System.ComponentModel.DataAnnotations;


namespace TeamUP.Data.Party
{
    public class TeamWorkData : EntityData
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? TeamSize { get; set; }
        public DateTime? Deadline { get; set; }
        public bool? Done { get; set; }
    }
}
