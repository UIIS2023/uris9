﻿namespace KupacServis.Models.Mock
{
    public class JavnoNadmetanjeDto
    {
        /// <summary>
        /// ID javnog nadmetanja
        /// </summary>
        public Guid JavnoNadmetanjeId { get; set; }

        /// <summary>
        ///  Datum održavanja javnog nadmetanja
        /// </summary>
        public DateTime Datum { get; set; }

        /// <summary>
        ///  Vreme početka javnog nadmetanja
        /// </summary>
        public DateTime VremePocetka { get; set; }

        /// <summary>
        ///  Vreme kraja javnog nadmetanja
        /// </summary>
        public DateTime VremeKraja { get; set; }

        /// <summary>
        /// Početna cijena zemljišta po hektaru
        /// </summary>
        public int PocetnaCenaPoHektaru { get; set; }

        /// <summary>
        ///  Izuzeto javno nadmetanje
        /// </summary>
        public Boolean Izuzeto { get; set; }


        /// <summary>
        /// Izlicitirana cijena
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
    }
}
