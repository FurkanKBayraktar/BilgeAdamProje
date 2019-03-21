using BilgeAdam.Core.Core.Entity;
using BilgeAdam.Map.Map.Options;
using BilgeAdam.Model.Model.Entities;
using BilgeAdam.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdam.DAL
{
    public class ProjectContext:DbContext
    {
        public ProjectContext() : base("BilgeAdam") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new OrderDetailMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new DepartmentMap());
            modelBuilder.Configurations.Add(new StoreMap());
            modelBuilder.Configurations.Add(new SupplierMap());

            base.OnModelCreating(modelBuilder);
        }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public override int SaveChanges()
        {

            var modifiedEntries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            string identity = WindowsIdentity.GetCurrent().Name;
            string computerName = Environment.MachineName;
            DateTime date = DateTime.Now;
            string ip = RemoteIp.IpAddress;

            foreach (var item in modifiedEntries)
            {
                CoreEntity entity = item.Entity as CoreEntity;
                if (item != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        entity.Status = Core.Core.Entity.Enum.Status.Active;
                        entity.CreatedADUserName = identity;
                        entity.CreatedComputerName = computerName;
                        entity.CreatedDate = date;
                        entity.CreatedIp = ip;
                    }
                    else if (item.State == EntityState.Modified)
                    {
                        //entity.Status = Core.Core.Entity.Enum.Status.Updated;
                        entity.ModifiedADUserName = identity;
                        entity.ModifiedComputerName = computerName;
                        entity.ModifiedDate = date;
                        entity.ModifiedIp = ip;
                    }
                }
            }



            return base.SaveChanges();
        }
    }
}
