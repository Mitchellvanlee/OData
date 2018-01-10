namespace ODataPOC.Models
{
    public class Contract
    {
        public int ContractId { get; set; }
        public enum ContractType
        {
            Financiering = 0,
            Verzekering,
            Onbekend,
        }
        public ContractType Financiering { get; set; }
        public int Jaar { get; set; }
    }
}