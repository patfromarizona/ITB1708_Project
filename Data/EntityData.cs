
namespace TeamUP.Data {
    public abstract class EntityData {
        public static string NewId => Guid.NewGuid().ToString();
        public string Id { get; set; } = NewId;
    }
}
