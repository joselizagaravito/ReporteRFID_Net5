using Microsoft.EntityFrameworkCore;
using PyS.RFID.APIRest.DTOs;
using PyS.RFID.APIRest.Models;

#nullable disable

namespace PyS.RFID.APIRest.Context
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        public virtual DbSet<LecturasTagDto> LecturasTagDtos{ get; set; }
        public virtual DbSet<Articulo> Articulos { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Local> Locals { get; set; }
        public virtual DbSet<Modulo> Modulos { get; set; }
        public virtual DbSet<ReadTag> ReadTags { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<UviewLecturasDelDium> UviewLecturasDelDia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=SQL5078.site4now.net;User ID=DB_A6BF8E_pedroclavijo_admin;Password=Soloparati12;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.Property(e => e.CodigoArticulo)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.LastTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Precio)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RowState)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('A')")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.ToTable("Empresa");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.RowState)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('A')")
                    .IsFixedLength(true);

                entity.Property(e => e.Ruc)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("RUC");
            });

            modelBuilder.Entity<Local>(entity =>
            {
                entity.ToTable("Local");

                entity.Property(e => e.Dirección)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RowState)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('A')")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Modulo>(entity =>
            {
                entity.ToTable("Modulo");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdate).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RowState)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ReadTag>(entity =>
            {
                entity.ToTable("ReadTag");

                entity.Property(e => e.AntId).HasColumnName("AntID");

                entity.Property(e => e.Color)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Epc)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("EPC");

                entity.Property(e => e.FirstReadTime).HasColumnType("datetime");

                entity.Property(e => e.LastTime).HasColumnType("datetime");

                entity.Property(e => e.ModuloId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModuloRol)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Rssi).HasColumnName("RSSI");

                entity.Property(e => e.Tag).HasColumnName("TAG");

                entity.Property(e => e.Tid)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("TID");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("Tag");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AntId).HasColumnName("AntID");

                entity.Property(e => e.Epc)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("EPC");

                entity.Property(e => e.LastTime).HasColumnType("datetime");

                entity.Property(e => e.RowState)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Rssi).HasColumnName("RSSI");

                entity.Property(e => e.Tag1).HasColumnName("TAG");

                entity.Property(e => e.Tid)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("TID");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.ApellidoMaterno)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Cargo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Celular)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("DNI");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordSalt)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.RowState)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('A')")
                    .IsFixedLength(true);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UviewLecturasDelDium>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("uview_LecturasDelDia");

                entity.Property(e => e.AntId).HasColumnName("AntID");

                entity.Property(e => e.Color)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Epc)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("EPC");

                entity.Property(e => e.FirstReadTime).HasColumnType("datetime");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.LastTime).HasColumnType("datetime");

                entity.Property(e => e.Rssi).HasColumnName("RSSI");

                entity.Property(e => e.Tag).HasColumnName("TAG");

                entity.Property(e => e.Tid)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("TID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
