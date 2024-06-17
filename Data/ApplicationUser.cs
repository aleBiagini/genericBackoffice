using Microsoft.AspNetCore.Identity;

namespace GenericBackoffice.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        string Name { get; set; }
        
        [PersonalData]
        string Surname { get; set; }

        [PersonalData]
        string Address { get; set; }

        [PersonalData]
        string FiscalCode { get; set; }

        [PersonalData]
        string City { get; set; }

        [PersonalData]
        string Cap { get; set; }
    }

}
