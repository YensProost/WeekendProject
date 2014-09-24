using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeekendProject.DAL.Model
{
    public class Boek
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int BoekId { get; set; }
        public virtual int PersoonId { get; set; }
        public virtual string Titel { get; set; }
        public virtual string Auteur { get; set; }
        
        [ForeignKey("PersoonId")]
        public virtual Persoon Persoon { get; set; }
    }
}