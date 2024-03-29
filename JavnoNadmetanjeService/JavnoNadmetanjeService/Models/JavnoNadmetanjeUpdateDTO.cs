﻿namespace JavnoNadmetanjeService.Models
{
    public class JavnoNadmetanjeUpdateDto
    {
        /// <summary>
        /// ID javnog nadmetanja
        /// </summary>
        public Guid JavnoNadmetanjeID { get; set; }
        /// <summary>
        ///  Datum održavanja javnog nadmetanja
        /// </summary>
        public DateTime Datum { get; set; }
        /// <summary>
        ///  Vreme početka javnog nadmetanja
        /// </summary>
        public string VremePocetka { get; set; }
        /// <summary>
        ///  Vreme kraja javnog nadmetanja
        /// </summary>
        public string VremeKraja { get; set; }
        /// <summary>
        /// Početna cena po hektaru
        /// </summary>
        public int PocetnaCenaPoHektaru { get; set; }
        /// <summary>
        ///  Informacija o tome da li je javno nadmetanje izuzeto
        /// </summary>
        public bool Izuzeto { get; set; }
        /// <summary>
        /// ID tipa javnog nadmetanja
        /// </summary>
        public Guid TipJavnogNadmetanjaID { get; set; }
        /// <summary>
        /// ID statusa javnog nadmetanja
        /// </summary>
        public Guid StatusJavnogNadmetanjaID { get; set; }
        /// <summary>
        /// Izlicitirana cena
        /// </summary>
        public int IzlicitiranaCena { get; set; }
        /// <summary>
        /// Vremenski period zakupa
        /// </summary>
        public int PeriodZakupa { get; set; }
        /// <summary>
        /// Broj učesnika u javnom nadmetanju
        /// </summary>
        public int BrojUcesnika { get; set; }
        /// <summary>
        /// Visina dopune depozita
        /// </summary>
        public int VisinaDopuneDepozita { get; set; }
        /// <summary>
        /// Krug javnog nadmetanja 
        /// </summary>
        public int Krug { get; set; }
        /// <summary>
        /// Lista id-jeva licitanata
        /// </summary>
        public List<Guid> LicitantiID { get; set; }
        /// <summary>
        /// Lista id-jeva prijavljenih kupaca
        /// </summary>
        public List<Guid> PrijavljeniKupciID { get; set; }
        /// <summary>
        /// Lista id-jeva parcela
        /// </summary>
        public List<int> ParceleID { get; set; }
        /// <summary>
        /// ID adrese javnog nadmetanja
        /// </summary>
        public Guid AdresaID { get; set; }
        /// <summary>
        /// ID kupca koji je dostavio najbolju ponudu
        /// </summary>
        public Guid KupacID { get; set; }

    }
}
