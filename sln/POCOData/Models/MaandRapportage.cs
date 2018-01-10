namespace POCOData.Models
{
    public class MaandRapportage
    {
        public int MaandRapportageId { get; set; }
        public int VerkoperId { get; set; }
        public string Verkoper { get; set; }
        public string SubAgent { get; set; }
        public int Financiering { get; set; }
        public int Verzekering { get; set; }
        public int Totaal { get; set; }
        public string Kantoor { get; set; }
    }
}