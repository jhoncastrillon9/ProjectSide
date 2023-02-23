using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectSide.Infrastructure.Database.DatabaseEntities;

namespace ProjectSide.Infrastructure.Database.BoundedContexts
{
	public class ProjectSideContext : DbContext
	{
		public ProjectSideContext(DbContextOptions<ProjectSideContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>()
				.HasOne(p => p.Company)
				.WithMany(o => o.Users)
				.HasForeignKey(p => p.CompanyId);
		}
		public DbSet<Company> Companies { get; set; }
		public DbSet<User> Users { get; set; }
	}
}
