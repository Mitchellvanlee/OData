using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ODataPOC.Models;

namespace ODataPOC.Context
{
    public class ODataPOCContext
    {
        public List<Verkoper> Verkopers { get; set; }
        public List<Contract> Contracten { get; set; }

        public ODataPOCContext()
        {
            var contracten1 = new List<Contract>
            {
                new Contract {ContractId = 1, Financiering = Contract.ContractType.Financiering, Jaar = 2000}
            };

            var contracten2 = new List<Contract>
            {
                new Contract {ContractId = 2, Financiering = Contract.ContractType.Financiering, Jaar = 2001},
                new Contract {ContractId = 3, Financiering = Contract.ContractType.Verzekering, Jaar = 2003}
            };

            var contracten3 = new List<Contract>
            {
                new Contract {ContractId = 4, Financiering = Contract.ContractType.Financiering, Jaar = 2006},
                new Contract {ContractId = 5, Financiering = Contract.ContractType.Financiering, Jaar = 2002},
                new Contract {ContractId = 6, Financiering = Contract.ContractType.Verzekering, Jaar = 2002}
            };

            var contracten4 = new List<Contract>
            {
                new Contract {ContractId = 7, Financiering = Contract.ContractType.Financiering, Jaar = 2015},
                new Contract {ContractId = 8, Financiering = Contract.ContractType.Verzekering, Jaar = 2004},
                new Contract {ContractId = 9, Financiering = Contract.ContractType.Verzekering, Jaar = 2007},
                new Contract {ContractId = 10, Financiering = Contract.ContractType.Financiering, Jaar = 2005}
            };

            var contracten5 = new List<Contract>
            {
                new Contract {ContractId = 11, Financiering = Contract.ContractType.Financiering, Jaar = 2004},
                new Contract {ContractId = 12, Financiering = Contract.ContractType.Financiering, Jaar = 2008},
                new Contract {ContractId = 13, Financiering = Contract.ContractType.Verzekering, Jaar = 2007},
                new Contract {ContractId = 14, Financiering = Contract.ContractType.Verzekering, Jaar = 2006},
                new Contract {ContractId = 15, Financiering = Contract.ContractType.Financiering, Jaar = 2005}
            };
            Verkopers = new List<Verkoper>
            {
                new Verkoper {Contracten = contracten1, Naam = "Verkoper1", SubAgent = new SubAgent {SubAgentId = 1, Naam = "SubAgent1", Kantoor = new Kantoor {KantoorId = 1, Naam = "Kantoor1"}}, VerkoperId = 1},
                new Verkoper {Contracten = contracten2, Naam = "Verkoper2", SubAgent = new SubAgent {SubAgentId = 2, Naam = "SubAgent2", Kantoor = new Kantoor {KantoorId = 2, Naam = "Kantoor2"}}, VerkoperId = 2},
                new Verkoper {Contracten = contracten3, Naam = "Verkoper3", SubAgent = new SubAgent {SubAgentId = 3, Naam = "SubAgent3", Kantoor = new Kantoor {KantoorId = 3, Naam = "Kantoor3"}}, VerkoperId = 3},
                new Verkoper {Contracten = contracten4, Naam = "Verkoper4", SubAgent = new SubAgent {SubAgentId = 4, Naam = "SubAgent4", Kantoor = new Kantoor {KantoorId = 4, Naam = "Kantoor4"}}, VerkoperId = 4},
                new Verkoper {Contracten = contracten5, Naam = "Verkoper5", SubAgent = new SubAgent {SubAgentId = 5, Naam = "SubAgent5", Kantoor = new Kantoor {KantoorId = 5, Naam = "Kantoor5"}}, VerkoperId = 5},
                new Verkoper {Contracten = contracten1, Naam = "Verkoper1", SubAgent = new SubAgent {SubAgentId = 6, Naam = "SubAgent6", Kantoor = new Kantoor {KantoorId = 6, Naam = "Kantoor6"}}, VerkoperId = 6}
            };
            Contracten = contracten1.Concat(contracten2)
                .Concat(contracten3)
                .Concat(contracten4)
                .Concat(contracten5)
                .ToList();
        }
    }
}