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
    [Serializable]
    class Bolletta
    {
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

        public Bolletta(string tipoMateria, double spesaMateria, double spesaTrasportoGestioneContatore, double oneriSistema, double QVD)
        {
            this.tipoMateria = tipoMateria;
            this.spesaMateria = spesaMateria;
            this.spesaTrasportoGestioneContatore = spesaTrasportoGestioneContatore;
            this.oneriSistema = oneriSistema;
            this.QVD = QVD;
        }

        public string GetTipoMateria()
        {
            return tipoMateria;
        }

        public double GetSpesaMateria()
        {
            return spesaMateria;
        }

        public double GetSpesaTrasportoGestioneContatore()
        {
            return spesaTrasportoGestioneContatore;
        }

        public double GetOneriSistema()
        {
            return oneriSistema;
        }

        public double GetQVD()
        {
            return QVD;
        }

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

        public double CalcoloCostoBolletta(double consumo, double rendimento)
        {
            return (spesaMateria * consumo)/rendimento + spesaTrasportoGestioneContatore + oneriSistema + QVD;
        }

        new public virtual string ToString()
        {
            return $"Bolletta di {tipoMateria}: {spesaMateria} - {spesaTrasportoGestioneContatore} euro - {oneriSistema} euro - {QVD} euro";
        }
    }
}
