

public class SuperHero {
    public Guid Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public HeroDetail Detail { get; set; } = new HeroDetail();
}