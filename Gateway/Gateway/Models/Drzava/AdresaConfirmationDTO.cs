﻿namespace Gateway.Models.Drzava
{
    public class AdresaConfirmationDto
    {
        public Guid AdresaID { get; set; }
        public string? Ulica { get; set; }
        public string? Broj { get; set; }
        public string? Mesto { get; set; }
        public string? PostanskiBroj { get; set; }
        public Guid DrzavaID { get; set; }
    }
}
