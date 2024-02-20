using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPokemon.Models.EntityFramework
{
    [Table("pokemon")]
    public class Pokemon
    {
        [Key]
        [Column("idpokemon")]
        public int Id { get; set; }

        [Column("nompokemon")]
        [StringLength(50)]
        public string Nom { get; set; }

        [Column("type1pokemon")]
        [StringLength(50)]
        public string Type1 { get; set; }

        [Column("type2pokemon")]
        [StringLength(50)]
        public string? Type2 { get; set; }

        [Column("basepvpokemon")]
        [Range(1,1000)]
        public int BasePV { get; set; }

        [InverseProperty(nameof(Capture.PokemonCapture))]
        public virtual ICollection<Capture> CapturesPokemon { get; set; }
    }
}
