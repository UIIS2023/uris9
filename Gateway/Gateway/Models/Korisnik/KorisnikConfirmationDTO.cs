﻿namespace Gateway.Models.Korisnik
{
    public class KorisnikConfirmationDto
    {
        public int Id { get; set; }
        public string? KorisnickoIme { get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public int TipKorisnikaId { get; set; }
    }
}
