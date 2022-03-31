
namespace TeamUP.Data
{
    public class EntityData
    {
        public static string NewId => Guid.NewGuid().ToString();
        public string Id { get; set; } = NewId;
    }
}
