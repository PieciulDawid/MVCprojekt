using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MVCprojekt.Models
{
    // Możesz dodać dane profilu dla użytkownika, dodając więcej właściwości do klasy ApplicationUser. Odwiedź stronę https://go.microsoft.com/fwlink/?LinkID=317594, aby dowiedzieć się więcej.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Element authenticationType musi pasować do elementu zdefiniowanego w elemencie CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Dodaj tutaj niestandardowe oświadczenia użytkownika
            return userIdentity;
        }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Address { get; set; }

        public int PageSize { get; set; }

        public bool IsBlocked { get; set; }

        public virtual ICollection<OrderModel> Orders { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<CategoryModel> CategoryModels { get; set; }

        public DbSet<EmployeeModel> EmployeeModels { get; set; }

        public DbSet<OrderModel> OrderModels { get; set; }

        public DbSet<OrderProductModel> OrderProductModels { get; set; }

        public DbSet<PositionModel> PositionModels { get; set; }

        public DbSet<ProductModel> ProductModels { get; set; }

        public DbSet<CounterModel> CounterModels { get; set; }
    }
}