﻿using System.ComponentModel.DataAnnotations;

namespace Uris.DTO
{
    public class KatastarskaOpstinaDto
    {
        public int Id { get; set; }

        public string? Naziv { get; set; }

        public string? Okrug { get; set; }
    }
}
