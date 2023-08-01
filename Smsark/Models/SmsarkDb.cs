using Microsoft.EntityFrameworkCore;


namespace Smsark.Models
{
    public class SmsarkDb:DbContext
    {
           
        public SmsarkDb (DbContextOptions<SmsarkDb> options) :base(options)
        {

        }
        public DbSet<Apartment> apartments { get; set; }
        public DbSet<Room> Rooms  { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Owner> owners { get; set; }
        public DbSet<Reservation> reservations { get; set; }
        public DbSet<Bed> Beds { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
               .HasOne(e => e.apartmentItem)
               .WithOne(e => e.reservation)
                .HasForeignKey<Room>(e => e.RoomId)
                .IsRequired();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {

            optionBuilder.UseSqlServer(@"
                           Server=IBRAHIM;
                           Database = SmsarkDB1;
                           Trusted_Connection = True;
                           TrustServerCertificate = True;");

        }
    }
}
