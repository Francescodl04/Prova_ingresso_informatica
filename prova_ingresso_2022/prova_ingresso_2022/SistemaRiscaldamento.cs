using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace prova_ingresso_2022
{
    [Serializable]
    class SistemaRiscaldamento
    {
        [JsonProperty]
        protected string nome { get; set; }
        [JsonProperty]
        protected string tipo { get; set; }
        [JsonProperty]
        protected string rendimento { get; set; }
        [JsonProperty]
        protected double costoMacchina { get; set; }
        [JsonProperty]
        protected double costoInstallazione { get; set; }
        [JsonProperty]
        protected string fonteRiscaldamento { get; set; }

        public SistemaRiscaldamento(string nome, string tipo, string rendimento, double costoMacchina, double costoInstallazione, string fonteRiscaldamento)
        {
            this.nome = nome;
            this.tipo = tipo;
            this.rendimento = rendimento;
            this.costoMacchina = costoMacchina;
            this.costoInstallazione = costoInstallazione;
            this.fonteRiscaldamento = fonteRiscaldamento;
        }

        public string GetNome()
        {
            return nome;
        }

        public string GetTipo()
        {
            return tipo;
        }

        public string GetRendimento()
        {
            return rendimento;
        }

        public double GetCostoMacchina()
        {
            return costoMacchina;
        }

        public double GetCostoInstallazione()
        {
            return costoInstallazione;
        }

        public string GetFonteRiscaldamento()
        {
            return fonteRiscaldamento;
        }

        public double CostoTotale()
        {
            return costoMacchina + costoInstallazione;
        }

        public List<SistemaRiscaldamento> NuovoSistemaRiscaldamento(List<SistemaRiscaldamento> sistemiRiscaldamento)
        {
            sistemiRiscaldamento.Add(new SistemaRiscaldamento(nome, tipo, rendimento, costoMacchina, costoInstallazione, fonteRiscaldamento)
            {
                nome = nome,
                tipo = tipo,
                rendimento = rendimento,
                costoMacchina = costoMacchina,
                costoInstallazione = costoInstallazione,
                fonteRiscaldamento = fonteRiscaldamento
            });
            return sistemiRiscaldamento;
        }

        public override string ToString()
        {
            return $"{nome} - {tipo} - {rendimento} - {costoMacchina} euro - {costoInstallazione} euro - {fonteRiscaldamento}";
        }
    }
}
