using Microsoft.EntityFrameworkCore;

namespace ApiPokemon.Models.EntityFramework
{
    public class PokemonDBContext : DbContext
    {
        public PokemonDBContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost;port=5432;Database=PokemonDB; uid=postgres; password=postgres;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dresseur>(entity =>
            {
                entity.HasIndex(d => d.Pseudo).IsUnique();
                entity.HasCheckConstraint("ck_dresseur_heuresdejeu", "heuredejeudresseur >= 0");
            });

            modelBuilder.Entity<Pokemon>(entity =>
            {
                entity.HasIndex(d => d.Nom).IsUnique();
            });

            modelBuilder.Entity<Capture>(entity =>
            {
                entity.HasKey(k => new { k.IdDresseur, k.IdPokemon }).HasName("pk_capture");
                entity.HasOne(d => d.DresseurCapture)
                    .WithMany(c => c.CapturesDresseur)
                    .HasForeignKey(c => c.IdDresseur)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_capture_id_dresseur");

                entity.HasOne(d => d.PokemonCapture)
                    .WithMany(c => c.CapturesPokemon)
                    .HasForeignKey(c => c.IdPokemon)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_capture_id_pokemon");
            });
        }
    }
}
