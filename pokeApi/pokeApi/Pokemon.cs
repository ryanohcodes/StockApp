using System;
namespace pokeApi
{   // this is our model, schema, and what shows up on the database.
    // MAKE SURE ANGULAR IS CONSISTENT WITH THIS SCHEMA (FLOATS)
	public class Pokemon
	{
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public int Weight { get; set; }
        public float Height { get; set; }
        public int Dexid { get; set; }
    }
}

