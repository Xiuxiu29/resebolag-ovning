///<summary>
/// Namn: Xiu xiu 
/// klass:SY21
/// I den här fil finns super klassen för sub klassen och olika egenskaper för olika sub klasser. 
/// </summary>

using reseprogram;
using System.Text.RegularExpressions;

namespace reseprogram
{
    /// <summary>
    /// Den är en super klass och en ritning för hur sub klassen ska ser ut. 
    /// </summary>
    abstract class Resebolag
    {
        protected string Namn { get; set; }
        protected string Ort { get; set; }
        protected double Betyg { get; set; }


        public Resebolag(string namn, string ort, double betyg)
        {
            if(betyg > 5) { betyg = 5; }            //Om betyger är större än 5 så = 5
            if(betyg < 0) { betyg = 0; }            //Om betyger äe mindre än 0 så = 0

            Namn = namn;
            Ort = ort;
            Betyg = betyg;
        }

        public abstract string getInfo();

        public string getNamn()
        {
            return Namn;
        }
        public bool CompareName(string input)           //Järmföra med namn man måttar in från program
        {
            if(input == this.Namn)
            {
                return true;                           //Om string input är = nån av de namn är true
            }
            return false;                               //Annars false
        }
    }
    /// <summary>
    /// De här är sub kalssen som har olika egenskaper för olika verksamheter. 
    /// </summary>
    class BB : Resebolag
    {
        private int Pris { get; set; }
        int rum = 2;
        public BB(string namn, string ort, double betyg, int pris) : base(namn, ort, betyg)
        {
            Pris = pris;
        }
        public override string getInfo()
        {
            return "Namn: " + Namn + 
                " Ort: " + Ort + 
                " Betyg: " + Betyg;
        }
    }

    class Hotell : Resebolag
    {
        private string Rumtyp { get; set; }
        private int Rum { get; set; }
        public Hotell(string namn, string ort, int rum, double betyg, string rumtyp) : base(namn, ort, betyg)
        {
            Rumtyp = rumtyp;
            Rum = rum;
        }
        public override string getInfo()
        {
            return "Namn: " + Namn + " Ort: " + Ort + " Rum: " + Rum + " Betyg: " + Betyg + " Rumtyp: " + Rumtyp;
        }
    }
    class Vandrarhem : Resebolag
    {
        private int Rum { get; set; }
        public Vandrarhem(string namn, string ort, int rum, double betyg) : base(namn, ort, betyg)
        {
            Rum = rum;
        }
        public override string getInfo()
        {
            return "Namn: " + Namn + " Ort: " + Ort + "Rum: " + Rum + "Betyg: " + Betyg + "Rum" + Rum;

        }

    }

    
}