using TeamUP.Data;
using TeamUP.Data.Party;

namespace TeamUP.Domain
{
    public abstract class Entity
    {
        protected const string defaultStr = "Underfined";
        protected const bool defaultBool = false;
        protected const int defaultInt = 1;
        private static readonly DateTime defaultDate = DateTime.MinValue;
        protected static string getValue(string? v) => v ?? defaultStr;
        protected static bool getValue(bool? v) => v ?? defaultBool;
        protected static int getValue(int? v) => v ?? defaultInt;
        protected static IsoGender getValue(IsoGender? v) => v ?? IsoGender.NotApplicable;
        protected static DateTime getValue(DateTime? v) => v ?? defaultDate;
    }
    public abstract class Entity<TData>: Entity where TData: EntityData, new()
    {
        private readonly TData data;
        public TData Data => data;
        public Entity() : this(new TData()) { }
        public Entity(TData d) => data = d;
        public string Id => getValue(Data?.Id);
    }
}
