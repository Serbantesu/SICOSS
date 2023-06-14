using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class JcervantesSicossContext : DbContext
{
    public JcervantesSicossContext()
    {
    }

    public JcervantesSicossContext(DbContextOptions<JcervantesSicossContext> options)
        : base(options)
    {
    }

    public virtual DbSet<SuperDigito> SuperDigitos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database = JCervantesSICOSS; Trusted_Connection=True; TrustServerCertificate=True; User ID=sa; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SuperDigito>(entity =>
        {
            entity.HasKey(e => e.IdSuperDigito).HasName("PK__SuperDig__29A62501DFE36B29");

            entity.ToTable("SuperDigito");

            entity.Property(e => e.FechaHora).HasColumnType("datetime");
            entity.Property(e => e.Numero)
                .HasMaxLength(23)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.SuperDigitos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__SuperDigi__IdUsu__1CF15040");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF975B93504B");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Username, "UQ__Usuario__536C85E4E1C2A040").IsUnique();

            entity.Property(e => e.Password).HasMaxLength(25);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
