using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPokemon.Models.EntityFramework
{
    [Table("capture")]
    public class Capture
    {
        [Key]
        [Column("idpokemon")]
        public int IdPokemon { get; set; }

        [Key]
        [Column("iddresseur")]
        public int IdDresseur { get; set; }

        [Column("datecapture", TypeName = "date")]
        public DateTime DateCapture { get; set; }

        [Column("surnompokemon")]
        [StringLength(50)]
        public string SurnomPokemon { get; set; }

        [ForeignKey(nameof(IdPokemon))]
        [InverseProperty(nameof(Pokemon.CapturesPokemon))]
        public virtual Pokemon PokemonCapture { get; set; }

        [ForeignKey(nameof(IdDresseur))]
        [InverseProperty(nameof(Dresseur.CapturesDresseur))]
        public virtual Dresseur DresseurCapture { get; set; }
    }
}
