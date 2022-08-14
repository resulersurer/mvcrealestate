using Microsoft.AspNetCore.Identity;

namespace MVCRealEstate.Data
{
    public class User : IdentityUser<Guid>
    {
        public string Name { get; set; }

    }
}
