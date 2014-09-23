using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeekendProject.DAL.Model
{
    public class Persoon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int PersoonId { get; set; }
        public virtual string Voornaam { get; set; }
        public virtual string Achternaam { get; set; }
        [NotMapped]
        public string Naam { get { return Voornaam + " " + Achternaam; } }

        public virtual List<Boek> Boeken { get; set; } 
    }
}