﻿namespace Mikroservis_Uplata.DTO
{
    public class LogDto
    {
        public LogLevel Level { get; set; }

        public string? Servis { get; set; }

        public string? Metoda { get; set; }

        public string? Poruka { get; set; }

        public Exception? Greska { get; set; }
    }
}
