using System.ComponentModel.DataAnnotations;

namespace Cogent.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}