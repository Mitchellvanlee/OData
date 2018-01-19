using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.OData.Edm;

namespace POCOData.Models
{
    [Table("Bedrijven")]
    public class Bedrijf : PlusAdviesModel
    {
        public Bedrijf()
        {
        }

        [StringLength(100)]
        public string Naam { get; set; }

        [StringLength(50)]
        public string Voorletters { get; set; }

        [StringLength(20)]
        public string Tussenvoegsel { get; set; }

        [StringLength(50)]
        public string Geslacht { get; set; }

        //        public DatumType5 Gebdatum { get; set; }
        public Date GeboorteDatum { get; set; }

        [StringLength(100)]
        public string Straat { get; set; }

        [StringLength(10)]
        public string Huisnummer { get; set; }

        [StringLength(10)]
        public string HuisnummerToevoeging { get; set; }

        [StringLength(10)]
        public string Postcode { get; set; }

        [StringLength(50)]
        public string Plaats { get; set; }

        [StringLength(20)]
        public string TelefoonNummer { get; set; }

        [StringLength(200)]
        public string EmailAdres { get; set; }

        [StringLength(100)]
        public string BedrijfsNaam { get; set; }

        [StringLength(20)]
        public string TelefoonNummerBedrijf { get; set; }

        [StringLength(20)]
        public string KvkNummer { get; set; }

        public Date OprichtingsDatum { get; set; }

        public decimal Fee { get; set; }

    }
}