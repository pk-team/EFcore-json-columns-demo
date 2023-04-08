

public class AppContext : DbContext {

    public DbSet<SuperHero> SuperHeroes => Set<SuperHero>();

    public AppContext(DbContextOptions<AppContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder) {

        var superHero = builder.Entity<SuperHero>();
        superHero.HasKey(s => s.Id);
        superHero
            .Property(s => s.Id)
            .ValueGeneratedOnAdd();
        superHero
            .Property(s => s.Name)
            .IsRequired();

        superHero.HasIndex(s => s.Name).IsUnique();
        superHero
            .OwnsOne(s => s.Detail, build => build.ToJson());
    }
}