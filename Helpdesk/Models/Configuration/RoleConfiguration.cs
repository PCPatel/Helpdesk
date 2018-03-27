using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Helpdesk.Models.Configuration
{
    public class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            //ToTable("Table Name");
            HasKey(x => x.Id);

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Name).HasMaxLength(20).IsRequired();

            HasMany(t => t.Users)
            .WithMany(t => t.Roles)
            .Map(m =>
            {
                m.ToTable("UserRoles");
                m.MapLeftKey("RoleID");
                m.MapRightKey("UserID");
            });
        }
    }
}