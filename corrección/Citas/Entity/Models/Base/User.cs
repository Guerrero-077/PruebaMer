using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models.Base
{
    public class User : BaseModel
    {
        public string name { get; set; }
        public string? password { get; set; }
        public string email { get; set; }
    }
}
