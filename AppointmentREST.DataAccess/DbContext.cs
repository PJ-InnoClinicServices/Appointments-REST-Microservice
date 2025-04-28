using AppointmentREST.Shared.Entites;
using Microsoft.EntityFrameworkCore;

namespace AppointmentREST.DataAccess;

 public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
 { 
     public DbSet<AppointmentEntity> Appointments { get; set; }
     
     public DbSet<AppointmentResultEntity> AppointmentResults { get; set; }
    }
