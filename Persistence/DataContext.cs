using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public static readonly ILoggerFactory loggerFactory
                   = LoggerFactory.Create(builder =>
                   {
                       builder.AddFilter((cat, level) =>
                       cat == DbLoggerCategory.Database.Command.Name
                          && level == LogLevel.Information)
                       .AddConsole();
                   }
                   );

        public DbSet<EmergencyContact> EmergencyContact { get; set; }
        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<BankDetails> BankDetails { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Documents> Documents { get; set; }
        public DbSet<SchedulePolicy> SchedulePolicie { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<Leaves> Leave { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>().ToTable("t_customers");
            builder.Entity<EmployeeDetails>().ToTable("t_employees");
            builder.Entity<SchedulePolicy>().ToTable("t_schedulePolicy");
            builder.Entity<JobTitle>().ToTable("t_jobTitle");
            builder.Entity<Address>().ToTable("t_address");
            builder.Entity<BankDetails>().ToTable("t_bankDetails");
            builder.Entity<Company>().ToTable("t_companies");
            builder.Entity<Office>().ToTable("t_offices").HasIndex(n => n.Code).IsUnique();
            builder.Entity<Department>().ToTable("t_department");
            builder.Entity<Documents>().ToTable("t_documents");
            builder.Entity<EmergencyContact>().ToTable("t_emergencyContact");
            builder.Entity<Events>().ToTable("t_events");
            builder.Entity<LeaveRequest>().ToTable("t_leaveRequest");
            builder.Entity<Leaves>().ToTable("t_leaves");
         
            
            base.OnModelCreating(builder);


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory)  //tie-up DbContext with LoggerFactory object
                .EnableSensitiveDataLogging();
        }
    }
}