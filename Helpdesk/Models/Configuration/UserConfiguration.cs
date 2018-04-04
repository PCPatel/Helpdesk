using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Helpdesk.Models.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Name).IsRequired().HasMaxLength(50);

            Property(x => x.UserName).IsRequired().HasMaxLength(10);
            
            Property(x => x.Password).IsRequired().HasMaxLength(12);

            HasIndex(x => x.Name).IsUnique(true);
            HasIndex(x => x.UserName).IsUnique(true);

            HasMany(t => t.Roles)
            .WithMany(t => t.Users);
        }
    }
}