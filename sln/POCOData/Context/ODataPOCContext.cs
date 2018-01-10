using System.Collections.Generic;
using System.Linq;
using POCOData.Models;

namespace POCOData.Context
{
    //Test data contains:
    //2000: 3 financiering / 3 verzekering
    //2001: 5 financiering / 3 verzekering
    //2010: 1 financiering / 0 verzekering
    public class ODataPOCContext
    {
        public List<Verkoper> Verkopers { get; set; }
        public List<Contract> Contracten { get; set; }

        public ODataPOCContext()
        {
            Cluster cluster1 = new Cluster {ClusterId = 1, Naam = "Eerste cluster"};
            Cluster cluster2 = new Cluster {ClusterId = 2, Naam = "Tweede cluster"};

            SubAgent subAgent1 = new SubAgent {Cluster = cluster1, Naam = "Subagent een", SubAgentId = 1};
            SubAgent subAgent2 = new SubAgent {Cluster = cluster1, Naam = "Subagent twee", SubAgentId = 2};
            SubAgent subAgent3 = new SubAgent {Cluster = cluster2, Naam = "Subagent drie", SubAgentId = 3};

            Verkoper verkoper1 = new Verkoper {Naam = "Verkoper nummer 1", SubAgent = subAgent1, VerkoperId = 1};
            Verkoper verkoper2 = new Verkoper {Naam = "Verkoper nummer 2", SubAgent = subAgent1, VerkoperId = 2};
            Verkoper verkoper3 = new Verkoper {Naam = "Verkoper nummer 3", SubAgent = subAgent1, VerkoperId = 3};
            Verkoper verkoper4 = new Verkoper {Naam = "Verkoper nummer 4", SubAgent = subAgent2, VerkoperId = 4};
            Verkoper verkoper5 = new Verkoper {Naam = "Verkoper nummer 5", SubAgent = subAgent2, VerkoperId = 5};
            Verkoper verkoper6 = new Verkoper {Naam = "Verkoper nummer 6", SubAgent = subAgent3, VerkoperId = 6};

            var contracten1 = new List<Contract>
            {
                new Contract
                {
                    ContractId = 1,
                    Financiering = Contract.ContractType.Financiering,
                    Jaar = 2000,
                    Maand = 1,
                    Verkoper = verkoper1
                }
            };

            var contracten2 = new List<Contract>
            {
                new Contract
                {
                    ContractId = 2,
                    Financiering = Contract.ContractType.Financiering,
                    Jaar = 2000,
                    Maand = 2,
                    Verkoper = verkoper2
                },
                new Contract
                {
                    ContractId = 3,
                    Financiering = Contract.ContractType.Verzekering,
                    Jaar = 2000,
                    Maand = 3,
                    Verkoper = verkoper3
                }
            };

            var contracten3 = new List<Contract>
            {
                new Contract
                {
                    ContractId = 4,
                    Financiering = Contract.ContractType.Financiering,
                    Jaar = 2001,
                    Maand = 7,
                    Verkoper = verkoper3
                },
                new Contract
                {
                    ContractId = 5,
                    Financiering = Contract.ContractType.Financiering,
                    Jaar = 2001,
                    Maand = 7,
                    Verkoper = verkoper3
                },
                new Contract
                {
                    ContractId = 6,
                    Financiering = Contract.ContractType.Verzekering,
                    Jaar = 2001,
                    Maand = 7,
                    Verkoper = verkoper4
                }
            };

            var contracten4 = new List<Contract>
            {
                new Contract
                {
                    ContractId = 7,
                    Financiering = Contract.ContractType.Financiering,
                    Jaar = 2010,
                    Maand = 2,
                    Verkoper = verkoper1
                },
                new Contract
                {
                    ContractId = 8,
                    Financiering = Contract.ContractType.Verzekering,
                    Jaar = 2001,
                    Maand = 1,
                    Verkoper = verkoper2
                },
                new Contract
                {
                    ContractId = 9,
                    Financiering = Contract.ContractType.Verzekering,
                    Jaar = 2000,
                    Maand = 3,
                    Verkoper = verkoper1
                },
                new Contract
                {
                    ContractId = 10,
                    Financiering = Contract.ContractType.Financiering,
                    Jaar = 2001,
                    Maand = 1,
                    Verkoper = verkoper3
                }
            };

            var contracten5 = new List<Contract>
            {
                new Contract
                {
                    ContractId = 11,
                    Financiering = Contract.ContractType.Financiering,
                    Jaar = 2001,
                    Maand = 5,
                    Verkoper = verkoper2
                },
                new Contract
                {
                    ContractId = 12,
                    Financiering = Contract.ContractType.Financiering,
                    Jaar = 2000,
                    Maand = 3,
                    Verkoper = verkoper4
                },
                new Contract
                {
                    ContractId = 13,
                    Financiering = Contract.ContractType.Verzekering,
                    Jaar = 2001,
                    Maand = 5,
                    Verkoper = verkoper5
                },
                new Contract
                {
                    ContractId = 14,
                    Financiering = Contract.ContractType.Verzekering,
                    Jaar = 2000,
                    Maand = 10,
                    Verkoper = verkoper5
                },
                new Contract
                {
                    ContractId = 15,
                    Financiering = Contract.ContractType.Financiering,
                    Jaar = 2001,
                    Maand = 9,
                    Verkoper = verkoper6
                }
            };

            Contracten = contracten1.Concat(contracten2)
                .Concat(contracten3)
                .Concat(contracten4)
                .Concat(contracten5)
                .ToList();
        }
    }
}

