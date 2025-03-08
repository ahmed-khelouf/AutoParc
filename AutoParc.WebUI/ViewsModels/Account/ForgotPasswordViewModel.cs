using System.ComponentModel.DataAnnotations;

namespace AutoParc.WebUI.ViewsModels.Account;

public class ForgotPasswordViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}