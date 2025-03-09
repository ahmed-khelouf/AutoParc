using Microsoft.AspNetCore.Identity;

namespace AutoParc.Model.Identity;

public class UserModel : IdentityUser
{
    public int? EntrepriseId { get; set; }
    public EntrepriseModel? Entreprise { get; set; }
}