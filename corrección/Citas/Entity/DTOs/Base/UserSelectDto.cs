using Entity.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.DTOs.Base
{
    public class UserSelectDto : BaseModelDto
    {
        public string name { get; set; }
        public string? password { get; set; }
        public string email { get; set; }
    }
}
