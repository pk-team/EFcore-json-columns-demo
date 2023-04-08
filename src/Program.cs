

var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile("appsettings.Development.json", optional: true);
var configuration = builder.Build();

var connectionString = configuration.GetConnectionString("DefaultConnection");
// new AppContext from connectionString UseSqlServer
var appContext = new AppContext(new DbContextOptionsBuilder<AppContext>().UseSqlServer(connectionString).Options);

appContext.Database.EnsureDeleted();
appContext.Database.EnsureCreated();

// names: Super Man, Batman, Spider Man
// generate 3 names
var superHeroNames = new List<string>() {
    "Superman", "Batman", "Spiderman", "hulk"
};

appContext.SuperHeroes.AddRange(superHeroNames.Select(name => 
new SuperHero() { 
    Name = name,
    Detail = new HeroDetail() { 
        Description = $"Description for {name}",
        SuperPower = $"Super Power for {name}"
    }    
}));

appContext.SaveChanges();

// get all super heros and console log name and details for each 
var superHeroes = appContext.SuperHeroes.ToList();
foreach (var superHero in superHeroes) {
    Console.WriteLine($"Name: {superHero.Name}");
    Console.WriteLine($"Description: {superHero.Detail.Description}");
    Console.WriteLine($"Super Power: {superHero.Detail.SuperPower}");
    Console.WriteLine();
}



