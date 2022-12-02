using System;
namespace pokeApi
{
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

