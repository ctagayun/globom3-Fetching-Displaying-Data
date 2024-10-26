using Microsoft.EntityFrameworkCore;

public class HouseDbContext: DbContext
 {
    //Create a property called "Houses" of type DbSet
    //The DBSet collection represents the database table itself.
    //We set the initial value of Houses to an empty DbSet using the Set method.
    public DbSet<HouseEntity> Houses => Set<HouseEntity> ();

   // public HouseDbContext(DbContextOptions<HouseDbContext> options) : base(options) { }
    
    //public DbSet<BidEntity> Bids => Set<BidEntity>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        options.UseSqlite($"Data Source={Path.Join(path, "houses.db")}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        SeedData.Seed(modelBuilder);
    }
 }