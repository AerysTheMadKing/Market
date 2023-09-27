using Market.Data;
using Market.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Models
{
    public class UserDataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public UserDataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(Configuration.GetConnectionString("UserDB"));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("User");

            modelBuilder.Entity<User>()
                .HasData(
                    new User
                    {
                        Id = 1,
                        UserName = "madscrip",
                        Password = "qwerty",
                        Age = 18,
                        IsPremiumMember = true


                    },
                    new User
                    {
                        Id = 2,
                        UserName = "alica",
                        Password = "qwerty",
                        Age = 15,
                        IsPremiumMember = true


                    });

            //modelBuilder.Entity<Weapon>()
            //    .ToTable("Weapon");

            //modelBuilder.Entity<Weapon>()
            //    .HasData(
            //        new Weapon
            //        {
            //            Id = 1,
            //            Title = "AK 47",
            //            Price = "17000 $",
            //            Description = "7,62-мм автомат Калашникова (АК)[4] — автомат, принятый на вооружение в СССР в 1949 году; индекс ГРАУ — 56-А-212. Был сконструирован в 1947 году М. Т. Калашниковым после провала предыдущего образца, АК-46, на конкурсных испытаниях 1946 года. В АК использованы технические решения, позаимствованные у других конструкторов.",
            //            Image = "https://images4.alphacoders.com/633/thumb-1920-633440.jpg",
            //            Created_at = DateTime.Now,
            //            Updated_at = DateTime.Now,
            //        },
            //        new Weapon
            //        {
            //            Id = 2,
            //            Title = "Beretta",
            //            Price = "10000 $",
            //            Description = "Пистоле́т (фр. pistolet ← фр. pistole от чеш. píšťala «пищаль, дудка») — ручное короткоствольное стрелковое оружие, предназначенное для поражения целей (живой силы и других) на дальности до 25-50 метров.",
            //            Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/61/M9-pistolet.jpg/640px-M9-pistolet.jpg",
            //            Created_at = DateTime.Now,
            //            Updated_at = DateTime.Now,
                    
            //        });





        }


    }
}
