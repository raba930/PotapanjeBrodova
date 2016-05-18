using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    public class SustavniPucač : IPucač
    {
        public SustavniPucač (IEnumerable<Polje> pogođena, Mreža mreža)
        {
            this.pogođenaPolja = new List<Polje>(pogođena);
            pogođenaPolja.Sort((a, b) => a.Redak - b.Redak + a.Stupac - b.Stupac);
            this.mreža = mreža;
        }

        public Polje UputiPucanj()
        {
            Orijentacija o = DajOrijentaciju();
            var liste = DajPoljaUNastavku(o);

            if (liste.Count() == 1)
                return liste.First().First();

            int indeks = slučajni.Next(liste.Count());
            return liste.ElementAt(indeks).First();

        }

        private Orijentacija DajOrijentaciju()
        {
            if (pogođenaPolja[0].Redak == pogođenaPolja[1].Redak)
                return Orijentacija.Horizontalno;

            return Orijentacija.Vertikalno;
        }

        private IEnumerable<IEnumerable<Polje>> DajPoljaUNastavku(Orijentacija orijentacija)
        {
            switch (orijentacija)
            {
                case Orijentacija.Horizontalno:
                    return DajPoljaUNastavku(Smjer.Lijevo, Smjer.Desno);
                case Orijentacija.Vertikalno:
                    return DajPoljaUNastavku(Smjer.Gore, Smjer.Dolje);
                default:
                    throw new NotImplementedException();
            }
        }

        private IEnumerable<IEnumerable<Polje>> DajPoljaUNastavku(Smjer smjer1, Smjer smjer2)
        {
            List<IEnumerable<Polje>> liste = new List<IEnumerable<Polje>>();
            int redakNula = pogođenaPolja[0].Redak;
            int stupacNula = pogođenaPolja[0].Stupac;
            var lista1 = mreža.DajPoljaUZadanomSmjeru(redakNula, stupacNula, smjer1);
            if (lista1.Count() > 0)
                liste.Add(lista1);

            int n = pogođenaPolja.Count() - 1;
            int redakN = pogođenaPolja[n].Redak;
            int stupacN = pogođenaPolja[n].Stupac;
            var lista2 = mreža.DajPoljaUZadanomSmjeru(redakN, stupacN, smjer2);
            if (lista2.Count() > 0)
                liste.Add(lista2);
            return liste;
        }


        List<Polje> pogođenaPolja;
        Mreža mreža;
        Random slučajni = new Random();
    }
}
