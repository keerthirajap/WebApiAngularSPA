namespace WebApi.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BindingModel.User;
    using BindingModel.V1._0;
    using BindingModel.V1._0.User;
    using Microsoft.EntityFrameworkCore;

    public class EFDataContext : DbContext
    {
        public DbSet<UserBindingModel> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=WebApiAngularSPA;Integrated Security=True");
        }
    }
}