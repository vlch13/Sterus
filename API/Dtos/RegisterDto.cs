using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
	public class RegisterDto
	{
		[Required]
		public string Name { get; set; }
		[Required]
		[RegularExpression("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$", ErrorMessage = "Пароль должнен содержать 1 большую букву, 1 малую, 1 число, 1 символ. Минимальная длина 6")]
		public string Password { get; set; }
	}
}