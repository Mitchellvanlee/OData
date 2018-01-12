namespace POCOData.Models
{
    public class Contract
    {
        public int ContractId { get; set; }
        public enum ContractType
        {
            Financiering,
            Verzekering,
            Onbekend
        }
        public Verkoper Verkoper { get; set; }
        public ContractType Financiering { get; set; }
        public int Jaar { get; set; }
        public int Maand { get; set; }
    }
}