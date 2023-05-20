using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using proyectoSC.ResponseModels;
using proyectoSC.Models;

namespace proyectoSC
{
    public partial class DatabaseContext : IdentityDbContext<UserModel>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DatoModel> Datos { get; set; } = null!;
        public virtual DbSet<DocumentoModel> Documentos { get; set; } = null!;
        public virtual DbSet<FotografiaModel> Fotografias { get; set; } = null!;
        public virtual DbSet<InventarioModel> Inventarios { get; set; } = null!;
        public virtual DbSet<MapaModel> Mapas { get; set; } = null!;
        public virtual DbSet<ParroquiaModel> Parroquias { get; set; } = null!;
        public virtual DbSet<ProvinciaModel> Provincias { get; set; } = null!;

        public virtual DbSet<RefreshToken> RefreshTokens { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            

            //Generación uuid tablas modelo
            builder.Entity<DatoModel>(o =>
                o.Property(x => x.Id)
                .HasDefaultValue("uuid_generate_v4()")
                .ValueGeneratedOnAdd());
            builder.Entity<DocumentoModel>(o =>
               o.Property(x => x.Id)
               .HasDefaultValue("uuid_generate_v4()")
               .ValueGeneratedOnAdd());
            builder.Entity<FotografiaModel>(o =>
               o.Property(x => x.Id)
               .HasDefaultValue("uuid_generate_v4()")
               .ValueGeneratedOnAdd());
            builder.Entity<InventarioModel>(o =>
               o.Property(x => x.Id)
               .HasDefaultValue("uuid_generate_v4()")
               .ValueGeneratedOnAdd());
            builder.Entity<MapaModel>(o =>
               o.Property(x => x.Id)
               .HasDefaultValue("uuid_generate_v4()")
               .ValueGeneratedOnAdd());
            builder.Entity<ParroquiaModel>(o =>
               o.Property(x => x.Id)
               .HasDefaultValue("uuid_generate_v4()")
               .ValueGeneratedOnAdd());
            builder.Entity<ProvinciaModel>(o =>
               o.Property(x => x.Id)
               .HasDefaultValue("uuid_generate_v4()")
               .ValueGeneratedOnAdd());



            base.OnModelCreating(builder);
        }
    }
}