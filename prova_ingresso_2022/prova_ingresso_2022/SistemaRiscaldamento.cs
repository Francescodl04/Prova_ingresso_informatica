/**
 * @name Francesco Di Lena, classe 5F
 * @date 24/09/2022
 * @file SistemaRiscaldamento.cs
**/

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace prova_ingresso_2022
{
    /**
     * @class SistemaRiscaldamento
     * @brief La classe SistemaRiscaldamento rappresenta il sistema di riscaldamento. Contiene i metodi per ottenere le informazioni sul riscaldamento, nonché per calcolarla e visualizzarne le caratteristiche.
     *        Inoltre è serializzabile, quindi può essere usata per il salvataggio dei sistemi di riscaldamento in JSON.
    **/        

    [Serializable]
    class SistemaRiscaldamento
    {
        [JsonProperty]
        protected string nome { get; set; }
        [JsonProperty]
        protected string tipo { get; set; }
        [JsonProperty]
        protected double rendimento { get; set; }
        [JsonProperty]
        protected double costoMacchina { get; set; }
        [JsonProperty]
        protected double costoInstallazione { get; set; }
        [JsonProperty]
        protected string fonteRiscaldamento { get; set; }

        /**
         * @fn public SistemaRiscaldamento(string nome, string tipo, double rendimento, double costoMacchina, double costoInstallazione, string fonteRiscaldamento)
         * @brief Metodo costruttore.
        **/ 

        public SistemaRiscaldamento(string nome, string tipo, double rendimento, double costoMacchina, double costoInstallazione, string fonteRiscaldamento)
        {
            this.nome = nome;
            this.tipo = tipo;
            this.rendimento = rendimento;
            this.costoMacchina = costoMacchina;
            this.costoInstallazione = costoInstallazione;
            this.fonteRiscaldamento = fonteRiscaldamento;
        }

        /**
         * @fn public string GetNome()
         * @brief Accesso alla variabile che ritorna il metodo.
         * @returns string nome
        **/

        public string GetNome()
        {
            return nome;
        }

        /**
         * @fn public string GetTipo()
         * @brief Accesso alla variabile che ritorna il metodo.
         * @returns string tipo
        **/

        public string GetTipo()
        {
            return tipo;
        }

        /**
         * @fn public double GetRendimento()
         * @brief Accesso alla variabile che ritorna il metodo.
         * @returns double rendimento
        **/

        public double GetRendimento()
        {
            return rendimento;
        }

        /**
        * @fn public double GetCostoMacchina()
        * @brief Accesso alla variabile che ritorna il metodo.
        * @returns double costoMacchina
        **/

        public double GetCostoMacchina()
        {
            return costoMacchina;
        }

        /**
        * @fn public double GetCostoInstallazione()
        * @brief Accesso alla variabile che ritorna il metodo.
        * @returns double costoInstallazione
        **/

        public double GetCostoInstallazione()
        {
            return costoInstallazione;
        }

        /**
        * @fn public string GetFonteRiscaldamento()
        * @brief Accesso alla variabile che ritorna il metodo.
        * @returns string fonteRiscaldamento
        **/

        public string GetFonteRiscaldamento()
        {
            return fonteRiscaldamento;
        }

        /**
         * @fn public List<SistemaRiscaldamento> NuovoSistemaRiscaldamento(List<SistemaRiscaldamento> sistemiRiscaldamento)
         * @param List<SistemaRiscaldamento> sistemiRiscaldamento: la lista su cui inserire i nuovi sistemi di riscaldamento
         * @brief Permette di aggiungere nella lista una nuova posizione in cui vengono inseriti i dati immessi da parte dell'utente.
         * @returns List<SistemaRiscaldamento> sistemiRiscaldamento
        **/

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

        /**
         * @fn public override string ToString()
         * @returns string : ritorna la stringa composta dalle caratteristiche del sistema di riscaldamento a cui si fa riferimento nell'istanza della classe.
        **/

        public override string ToString()
        {
            return $"{nome} - {tipo} - {rendimento} - {costoMacchina} euro - {costoInstallazione} euro - {fonteRiscaldamento}";
        }
    }
}
