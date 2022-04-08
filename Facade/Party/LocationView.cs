﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TeamUP.Data.Party;
using TeamUP.Domain.Party;

namespace TeamUP.Facade.Party
{
    public sealed class LocationView : BaseView
    {
        public string? Country { get; set; }
        public string? Currency { get; set; }
    }

    public sealed class LocationViewFactory : BaseViewFactory<LocationView, Location, LocationData>
    {
        protected override Location toEntity(LocationData d) => new(d);
        public override LocationView Create(Location? e)
        {
            var v = base.Create(e);
            return v;
        }
    }
}
