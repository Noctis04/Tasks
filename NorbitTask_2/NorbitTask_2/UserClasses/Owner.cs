using System.ComponentModel.DataAnnotations;

namespace NorbitTask_2.UserClasses
{
    public class Owner
    {
        [Key]
        public long Id { get; set; }
        public string Login { get; set; } = "";

        public string Password { get; set; } = "";

        public string NickName { get; set; } = "";

    }
}
