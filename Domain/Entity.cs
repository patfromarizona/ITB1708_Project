using TeamUP.Data;

namespace TeamUP.Domain
{
    public abstract class Entity
    {
        protected const string defaultStr = "Underfined";
        protected const bool defaultGender = true;
        protected const int defaultAge = 18;
        protected const int defalutYear = 1;
        protected const bool defaultDone = false;
        protected const int defaultTeamSize = 1;
        protected DateTime defaultDate = DateTime.MinValue;
    }
    public abstract class Entity<TData>: Entity where TData: EntityData, new()
    {
        private readonly TData data;
        public TData Data => data;
        public Entity() : this(new TData()) { }
        public Entity(TData d) => data = d;
        public string Id => Data?.Id ?? defaultStr;
    }
}
