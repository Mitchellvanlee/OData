using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace POCOData.Models
{
    public class KredietAanvraag : PlusAdviesModel
    {
        [Column(TypeName = "Date")] //TODO : remove
        public DateTime VervalDatum { get; set; }

        public int VervalDag { get; set; }
        public int VervalWeek { get; set; }
        public int VervalMaand { get; set; }
        public int VervalJaar { get; set; }

        [Column(TypeName = "Date")]
        public DateTime UitbetaaldDatum { get; set; }

        public int UitBetaaldDag { get; set; }
        public int UitBetaaldWeek { get; set; }
        public int UitBetaaldMaand { get; set; }
        public int UitBetaaldJaar { get; set; }

        public decimal LeenBedrag { get; set; }
        public bool DepotBedragGespecificeerd { get; set; }
        public decimal DepotBedrag { get; set; }
        public bool BlokkadeGespecificeerd { get; set; }
        public decimal Blokkade { get; set; }
        public bool RestSaldoGespecificeerd { get; set; }
        public decimal RestSaldo { get; set; }
        public bool DkPercGespecificeerd { get; set; }

        public decimal DkPerc { get; set; }
        public string Looptijd { get; set; }
        public bool TermijnbedragFieldGespecificeerd { get; set; }
        public decimal Termijnbedrag { get; set; }
        public decimal Maandrente { get; set; }
        public bool EffectieveJaarrenteGespecificeerd { get; set; }
        public decimal EffectieveJaarrente { get; set; }
        public bool NominaleJaarrenteGespecificeerd { get; set; }
        public decimal NominaleJaarrente { get; set; }

        /// <summary>
        /// Constructor zodat OData het object kan maken
        /// </summary>
        public KredietAanvraag()
        {
        }
    }
}