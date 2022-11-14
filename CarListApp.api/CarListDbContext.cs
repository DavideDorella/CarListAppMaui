using Microsoft.EntityFrameworkCore;
public class CarListDbContext : DbContext
{

    public CarListDbContext(DbContextOptions<CarListDbContext> options) : base(options)
    {

    }
    public DbSet<Car> Cars { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Car>().HasData(

        new Car
                {
                    Id = 1,
                    Make="Honda", 
                    Model = "Fit",
                    Vin = "ABC1"
                },
                new Car
                {
                    Id = 2,
                    Make="Toyota",
                    Model = "Prado",
                    Vin = "ABC2"
                },
                new Car
                {
                    Id = 3,
                    Make="Honda",
                    Model = "Civic",
                    Vin = "ABC3"
                },
                new Car
                {
                    Id = 4,
                    Make="Audi",
                    Model = "A5",
                    Vin = "ABC4"
                },
                new Car
                {
                    Id = 5,
                    Make="BMW",
                    Model = "M3",
                    Vin = "ABC5"
                },
                new Car
                {
                    Id=6,
                    Make="Nissan",
                    Model ="Dualis",
                    Vin="ABC6"
                },
                new Car
                {
                    Id=7,
                    Make="Nissan",
                    Model ="Murano",
                    Vin="ABC7"
                }

            ); 

    }

}

