using EncuestasClassLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncuestasClassLib
{
    public class ProcesoEncuestas
    {
        Encuesta[] contactables;
        public int CantContactables { get; private set; }

        int cantBicleta;
        int cantAuto;
        int cantTranspPublico;
        int cantEncuestas;

        public double PorcBicleta
        {
            get
            {
                double porc = 0;
                if (cantEncuestas > 0)
                    porc = 100d * cantBicleta / cantEncuestas;
                return porc;
            }
        }
        public double PorcAuto
        {
            get
            {
                double porc = 0;
                if (cantEncuestas > 0)
                    porc = 100d * cantAuto / cantEncuestas;
                return porc;
            }
        }
        public double PorcTranspPublico
        {
            get
            {
                double porc = 0;
                if (cantEncuestas > 0)
                    porc = 100d * cantTranspPublico / cantEncuestas;
                return porc;
            }
        }

        public ProcesoEncuestas()
        {
            contactables = new Encuesta[100];
            CantContactables = 0;
        }

        public void RegistrarEncuesta(Encuesta nuevo, bool puedeSerCantactado)
        {
            cantEncuestas++;

            if (nuevo.UsaBicicleta) cantBicleta++;
            if (nuevo.UsaAuto) cantAuto++;
            if (nuevo.UsaTransportePublico) cantTranspPublico++;

            if (puedeSerCantactado == true)
            {
                contactables[CantContactables] = nuevo;
                CantContactables++;
            }
        }

        public Encuesta VerContactable(int idx)
        {
            Encuesta buscado = null;
            if (idx >= 0 && idx < CantContactables)
                buscado = contactables[idx];
            return buscado;
        }

        public void OrdernarEncuestables()
        {
            QuickSort(contactables, 0, CantContactables - 1);
        }

        void QuickSort(Encuesta[] lista, int inicio, int fin)
        {
            if (fin > inicio)
            {
                #region particion
                Encuesta p = lista[inicio];
                int m = inicio + 1;
                int n = fin;
                Encuesta aux;

                while (m <= n)
                {
                    while (m <= fin && p.DistanciaASuDestino >= lista[m].DistanciaASuDestino) m++;
                    while (n > inicio && p.DistanciaASuDestino <= lista[n].DistanciaASuDestino) n--;

                    if (m < n)
                    {
                        aux = lista[m];
                        lista[m] = lista[n];
                        lista[n] = aux;
                    }
                }
                lista[inicio] = lista[n];
                lista[n] = p;
                #endregion

                if (inicio < n - 1)
                    QuickSort(lista, inicio, n - 1);
                if (n + 1 < fin)
                    QuickSort(lista, n + 1, fin);
            }
        }
    }
}
