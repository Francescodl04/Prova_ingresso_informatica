using System;
using System.Collections.Generic;

namespace prova_ingresso_2022
{
    class Bolletta
    {
        protected string tipoMateria { get; set; }
        protected double spesaMateria { get; set; }
        protected double spesaTrasportoGestioneContatore { get; set; }
        protected double oneriSistema { get; set; }
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

        public double CalcoloCostoBolletta()
        {
            return spesaMateria + spesaTrasportoGestioneContatore + oneriSistema + QVD;
        }

        public override string ToString()
        {
            return $"Bolletta di {tipoMateria}: {spesaMateria} - {spesaTrasportoGestioneContatore} - {oneriSistema} - {QVD}";
        }
    }

    class EnergiaElettrica:Bolletta
    {
        public EnergiaElettrica() : base(tipoMateria, spesaMateria, spesaTrasportoGestioneContatore, oneriSistema, QVD)
        {

        }
    }
}
