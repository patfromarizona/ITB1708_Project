using System.ComponentModel.DataAnnotations;


namespace TeamUP.Facade
{
    public class BaseView
    {
        [Required] public string Id { get; set; }
    }
}
