/**
 * @name Francesco Di Lena, classe 5F
 * @date 24/09/2022
 * @file Bolletta.cs
**/

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace prova_ingresso_2022
{
    /**
     * @class Bolletta
     * @brief La classe Bolletta rappresenta i costi annuali dell'energia. Contiene i metodi per ottenere le informazioni sulla bolletta, nonché per calcolarla e visualizzarne le caratteristiche.
     *        Inoltre è serializzabile, quindi può essere usata per il salvataggio delle bollette in JSON.
    **/
    
    [Serializable]
    class Bolletta
    {
        //Attributi

        [JsonProperty]
        protected string tipoMateria { get; set; }
        [JsonProperty]
        protected double spesaMateria { get; set; }
        [JsonProperty]
        protected double spesaTrasportoGestioneContatore { get; set; }
        [JsonProperty]
        protected double oneriSistema { get; set; }
        [JsonProperty]
        protected double QVD { get; set; }

        //Metodi

        /** 
         * @fn public Bolletta(string tipoMateria, double spesaMateria, double spesaTrasportoGestioneContatore, double oneriSistema, double QVD)
         * @brief Metodo costruttore della classe.
        **/

        public Bolletta(string tipoMateria, double spesaMateria, double spesaTrasportoGestioneContatore, double oneriSistema, double QVD)
        {
            this.tipoMateria = tipoMateria;
            this.spesaMateria = spesaMateria;
            this.spesaTrasportoGestioneContatore = spesaTrasportoGestioneContatore;
            this.oneriSistema = oneriSistema;
            this.QVD = QVD;
        }

        /**
         * @fn public string GetTipoMateria()
         * @brief Accesso alla variabile che ritorna il metodo.
         * @returns string tipoMateria
        **/

        public string GetTipoMateria()
        {
            return tipoMateria;
        }

        /**
         * @fn public double GetSpesaMateria()
         * @brief Accesso alla variabile che ritorna il metodo.
         * @returns double spesaMateria
        **/

        public double GetSpesaMateria()
        {
            return spesaMateria;
        }

        /**
         * @fn public double GetSpesaTrasportoGestioneContatore()
         * @brief Accesso alla variabile che ritorna il metodo.
         * @returns double spesaTrasportoGestioneContatore
        **/

        public double GetSpesaTrasportoGestioneContatore()
        {
            return spesaTrasportoGestioneContatore;
        }

        /**
         * @fn public double GetOneriSistema()
         * @brief Metodo di accesso alla variabile che ritorna.
         * @returns double oneriSistema
        **/

        public double GetOneriSistema()
        {
            return oneriSistema;
        }

        /**
         * @fn public double GetQVD()
         * @brief Metodo di accesso alla variabile che ritorna.
         * @returns double QVD
        **/

        public double GetQVD()
        {
            return QVD;
        }

        /**
         * @fn public List<Bolletta> NuovaBolletta(List<Bolletta> bollette)
         * @param List<Bolletta> bollette: la lista su cui inserire le nuove bollette
         * @brief Permette di aggiungere nella lista una nuova posizione in cui vengono inseriti i dati immessi da parte dell'utente.
         * @returns List<Bolletta> bollette
        **/

        public List<Bolletta> NuovaBolletta(List<Bolletta> bollette)
        {
            bollette.Add(new Bolletta(tipoMateria, spesaMateria, spesaTrasportoGestioneContatore, oneriSistema, QVD)
            {
                tipoMateria = tipoMateria,
                spesaMateria = spesaMateria,
                spesaTrasportoGestioneContatore = spesaTrasportoGestioneContatore,
                oneriSistema = oneriSistema,
                QVD = QVD
            });
            return bollette;
        }

        /**
         * @fn public double CalcoloCostoBolletta(double consumo, double rendimento)
         * @brief
         * @returns
        **/

        public double CalcoloCostoBolletta(double consumo, double rendimento)
        {
            return (spesaMateria * consumo)/rendimento + spesaTrasportoGestioneContatore + oneriSistema + QVD;
        }

        /**
         * @fn public override string ToString()
         * @returns string : ritorna la stringa composta dalle caratteristiche della bolletta a cui si fa riferimento nell'istanza della classe.
        **/

        public override string ToString()
        {
            return $"Bolletta di {tipoMateria}: {spesaMateria} - {spesaTrasportoGestioneContatore} euro - {oneriSistema} euro - {QVD} euro";
        }
    }
}
