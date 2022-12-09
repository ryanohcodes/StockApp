using System;
using Microsoft.EntityFrameworkCore;

namespace pokeApi.Data
{	// has a type of DbContext, which is an abstraction over the database,
	// essentially an api to load form or to save to a DB
	// single unit of work (repository pattern?)
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options){} //constructor
		
		public DbSet<Pokemon> Pokemon => Set<Pokemon>(); // Dbset represnets a table in the Db. This table is called Pokemon

    }
}

