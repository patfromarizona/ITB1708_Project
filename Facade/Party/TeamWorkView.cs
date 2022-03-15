﻿
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TeamUP.Data.Party;
using TeamUP.Domain.Party;

namespace TeamUP.Facade.Party
{
    public sealed class TeamWorkView : BaseView
    {
        [DisplayName("Name")] public string? Name { get; set; }
        [DisplayName("Description")] public string? Description { get; set; }
        [DisplayName("Team Size")] public int? TeamSize { get; set; }
        [DisplayName("Deadline")] public DateTime? Deadline { get; set; }
        [DisplayName("Done")] public bool? Done { get; set; }
        [DisplayName("Overview")] public string? Overview { get; set; }
    }
    public sealed class TeamWorkViewFactory : BaseViewFactory<TeamWorkView, TeamWork, TeamWorkData>
    {
        protected override TeamWork toEntity(TeamWorkData d) => new(d);
    }
}
