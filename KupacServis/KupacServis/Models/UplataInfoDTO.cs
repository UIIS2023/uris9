﻿namespace KupacServis.Models
{
    public class UplataInfoDTO
    {
        public int Id { get; set; }

        public string BrojRacuna { get; set; }

        public string PozivNaBroj { get; set; }

        public string SvrhaUplate { get; set; }

        public int Iznos { get; set; }

        public DateTime Datum { get; set; }

        public int KursID { get; set; }

    }
}
