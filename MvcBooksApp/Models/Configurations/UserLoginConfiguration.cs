using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MvcBooksApp.Models.Configurations
{
    public class UserLoginConfiguration : EntityTypeConfiguration<UserLogin>
    {
        public UserLoginConfiguration()
        {
            HasKey(x => new { x.LoginProvider, x.ProviderKey, x.UserId });

            ToTable("user_logins");

            HasIndex(x => x.UserId).IsUnique(false);

            Property(x => x.LoginProvider).HasColumnName("login_provider").IsRequired().HasMaxLength(128);
            Property(x => x.ProviderKey).HasColumnName("provider_key").IsRequired().HasMaxLength(128);
            Property(x => x.UserId).HasColumnName("user_id").IsRequired();

            HasRequired(x => x.User)
                .WithMany(x => x.Logins)
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(true);
        }
    }

    public class RelUserRoleConfiguration : EntityTypeConfiguration<RelUserRole>
    {
        public RelUserRoleConfiguration()
        {
            HasKey(x => new { x.UserId, x.RoleId });

            ToTable("user_in_roles");

            HasIndex(x => x.UserId).IsUnique(false);
            HasIndex(x => x.RoleId).IsUnique(false);

            Property(x => x.UserId).HasColumnName("user_id").IsRequired();
            Property(x => x.RoleId).HasColumnName("role_id").IsRequired();

            HasRequired(x => x.User)
                .WithMany(x => x.Roles)
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Role)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.RoleId)
                .WillCascadeOnDelete(false);

        }
    }

    public class UserClaimConfiguration : EntityTypeConfiguration<UserClaim>
    {
        public UserClaimConfiguration()
        {
            HasKey(x => x.Id);

            ToTable("user_claims");

            HasIndex(x => x.UserId).IsUnique(false);

            Property(x => x.Id).HasColumnName("id").IsRequired();
            Property(x => x.UserId).HasColumnName("user_id").IsRequired();
            Property(x => x.ClaimType).HasColumnName("claim_type").HasMaxLength(2048).IsRequired();
            Property(x => x.ClaimValue).HasColumnName("claim_value").HasMaxLength(2048).IsRequired();

            HasRequired(x => x.User)
                .WithMany(x => x.Claims)
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(false);

        }
    }

    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("users");

            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("id")
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.Email).HasColumnName("email").HasMaxLength(256).IsRequired();
            Property(x => x.EmailConfirmed).HasColumnName("email_confirmed").IsRequired();
            Property(x => x.PasswordHash).HasColumnName("passwordhash").HasMaxLength(2048);
            Property(x => x.SecurityStamp).HasColumnName("security_stamp").HasMaxLength(2048);
            Property(x => x.PhoneNumber).HasColumnName("phonenum").HasMaxLength(2048);
            Property(x => x.PhoneNumberConfirmed).HasColumnName("phonenum_confirmed").IsRequired();
            Property(x => x.TwoFactorEnabled).HasColumnName("twofactor_enabled").IsRequired();
            Property(x => x.LockoutEndDateUtc).HasColumnName("lockout_enddtutc");
            Property(x => x.LockoutEnabled).HasColumnName("lockout_enabled").IsRequired();
            Property(x => x.AccessFailedCount).HasColumnName("accessfailed_count").IsRequired();
            Property(x => x.UserName).HasColumnName("username").HasMaxLength(256).IsRequired();

            HasMany(x => x.UserRoles)
               .WithMany(x => x.UserModels)
               .Map(cs =>
               {
                   cs.MapLeftKey("user_id");
                   cs.MapRightKey("role_id");
                   cs.ToTable("user_in_roles");
               });

            HasIndex(x => x.UserName)
                .IsUnique();
        }
    }

    public class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            ToTable("user_roles");

            HasKey(x => x.Id);

            HasIndex(x => x.Name).IsUnique();

            Property(x => x.Id).HasColumnName("id").IsRequired();
            Property(x => x.Name).HasColumnName("name").HasMaxLength(256).IsRequired();
        }
    }
}
