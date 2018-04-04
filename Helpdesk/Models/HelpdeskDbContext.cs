namespace Helpdesk.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using System.Reflection;

    public class HelpdeskDbContext : DbContext
    {
        public HelpdeskDbContext()
            : base("name=HelpdeskDbContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Attachment> Attachments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                                      .Where(type => !String.IsNullOrEmpty(type.Namespace))
                                      .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                                           && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<Helpdesk.Models.ViewModel.ComponentViewModel> ComponentViewModels { get; set; }
    }
}