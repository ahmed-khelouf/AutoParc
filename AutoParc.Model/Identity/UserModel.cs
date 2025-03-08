using Microsoft.AspNetCore.Identity;

namespace AutoParc.Model.Identity;

public class UserModel : IdentityUser
{
    public string Role { get; set; } 
    
    public int? EntrepriseId { get; set; }
    public EntrepriseModel? Entreprise { get; set; }
}