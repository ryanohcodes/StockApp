using System;
using Microsoft.EntityFrameworkCore;

namespace pokeApi.Data
{
	public class DataContext : DbContext
	{
		
		public DataContext(DbContextOptions<DataContext> options) : base(options){}

		public DbSet<Pokemon> Pokemon => Set<Pokemon>();

	}
}

