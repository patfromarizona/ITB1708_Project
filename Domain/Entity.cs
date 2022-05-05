using TeamUP.Data;
using TeamUP.Data.Party;

namespace TeamUP.Domain
{
    public abstract class Entity
    {
        public const string DefaultStr = "Underfined";
        private const bool defaultBool = false;
        private const int defaultInt = 1;
        private static readonly DateTime defaultDate = DateTime.MinValue;
        protected static string getValue(string? v) => v ?? DefaultStr;
        protected static bool getValue(bool? v) => v ?? defaultBool;
        protected static int getValue(int? v) => v ?? defaultInt;
        protected static IsoGender getValue(IsoGender? v) => v ?? IsoGender.NotApplicable;
        protected static DateTime getValue(DateTime? v) => v ?? defaultDate;
        public abstract string Id { get; }
    }
    public abstract class Entity<TData>: Entity where TData: EntityData, new()
    {
        public TData Data { get; }
        public Entity() : this(new TData()) { }
        public Entity(TData d) => Data = d;
        public override string Id => getValue(Data?.Id);
    }
}
