using Microsoft.EntityFrameworkCore;

namespace BackEnd.Models;

public partial class FactoryContext : DbContext {
    public FactoryContext(DbContextOptions<FactoryContext> options)
        : base(options) {
    }

    public virtual DbSet<data> data { get; set; }

    public virtual DbSet<machine> machine { get; set; }

    public virtual DbSet<project> project { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        _ = modelBuilder.Entity<data>(entity => {
            _ = entity.HasKey(e => e.ID).HasName("PRIMARY");

            _ = entity.HasIndex(e => e.ProjectID, "ProjectID");

            _ = entity.HasOne(d => d.Project).WithMany(p => p.data)
                .HasForeignKey(d => d.ProjectID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("data_ibfk_1");
        });

        _ = modelBuilder.Entity<machine>(entity => {
            _ = entity.HasKey(e => e.ID).HasName("PRIMARY");

            _ = entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            _ = entity.Property(e => e.Name).HasMaxLength(255);
            _ = entity.Property(e => e.Place).HasColumnType("text");
        });

        _ = modelBuilder.Entity<project>(entity => {
            _ = entity.HasKey(e => e.ID).HasName("PRIMARY");

            _ = entity.HasIndex(e => e.MachineID, "MachineID");

            _ = entity.Property(e => e.RecordDateTime).HasColumnType("datetime");

            _ = entity.HasOne(d => d.Machine).WithMany(p => p.project)
                .HasForeignKey(d => d.MachineID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("project_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
