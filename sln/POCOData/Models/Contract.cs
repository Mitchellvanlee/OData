using System.Web.OData.Builder;

namespace POCOData.Models
{
    public class Contract
    {
        public int ContractId { get; set; }
        public enum ContractType
        {
            Financiering = 0,
            Verzekering = 1,
            Onbekend = 2
        }
        public Verkoper Verkoper { get; set; }
        public ContractType Financiering { get; set; }
        public int Jaar { get; set; }
        public int Maand { get; set; }
    }
}