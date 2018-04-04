using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Helpdesk.Models.Configuration
{
    public class ComponentConfiguration : EntityTypeConfiguration<Component>
    {
        public ComponentConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Name).IsRequired().HasMaxLength(50);
            HasIndex(x => x.Name).IsUnique(true);
        }
    }
}