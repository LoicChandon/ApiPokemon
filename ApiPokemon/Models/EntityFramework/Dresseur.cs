using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPokemon.Models.EntityFramework
{
    [Table("dresseur")]
    public class Dresseur
    {
        [Key]
        [Column("iddresseur")]
        public int Id { get; set; }

        [Column("pseudodresseur")]
        [StringLength(50)]
        public string Pseudo { get; set; }

        [Column("genredresseur")]
        [StringLength(50)]
        public string? Genre { get; set; }

        [Column("heuredejeudresseur")]
        public double HeureDeJeu { get; set; }

        [Column("datecreationdresseur",TypeName = "date")]
        public DateTime DateCreation { get; set; }

        [InverseProperty(nameof(Capture.DresseurCapture))]
        public virtual ICollection<Capture> CapturesDresseur { get; set; }
    }
}
