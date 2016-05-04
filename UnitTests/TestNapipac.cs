using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;

namespace UnitTests
{
    [TestClass]
    public class TestNapipac
    {
        [TestMethod]
        public void Napipac_ListaPoljaZaHorizontalniBrodDuljine3MoraSadrzavati15Polja()
        {
            Mreža m = new Mreža(1, 7);
            const int duljinaBroda = 3;
            napipac n = new napipac(m, duljinaBroda);
            Assert.AreEqual(15, n.DajKandidateZaHorizontalniBrod().Count());
        }
        //[TestMethod]
        //public void Napipac_ListaPoljaZaHorizontalniBrodDuljine3MoraSadrzavatiPoljaUOdredjenomBroju()
        //{
        //    Mreža m = new Mreža(1, 7);
        //    const int duljinaBroda = 3;
        //    napipac n = new napipac(m, duljinaBroda);
        //    Assert.AreEqual(15, n.DajKandidateZaHorizontalniBrod().Count());
        //}
        [TestMethod]
        public void Napipac_ListaPoljaZaVertikalniBrodDuljine3MoraSadrzavati15Polja()
        {
            Mreža m = new Mreža(5, 2);
            const int duljinaBroda = 4;
            napipac n = new napipac(m, duljinaBroda);
            Assert.AreEqual(16, n.DajKandidateZaVertikalniBrod().Count());
        }
    }
}
