﻿namespace ZalbaService.Models
{
    public class ZalbaUpdateDto
    {
        /// <summary>
        /// ID žalbe
        /// </summary>
        public Guid ZalbaID { get; set; }
        /// <summary>
        /// Datum podnošenja žalbe
        /// </summary>
        public DateTime DatumPodnosenjaZalbe { get; set; }
        /// <summary>
        /// Razlog žalbe
        /// </summary>
        public string RazlogZalbe { get; set; }
        /// <summary>
        /// Obrazloženje
        /// </summary>
        public string Obrazlozenje { get; set; }
        /// <summary>
        /// Broj nadmetanja
        /// </summary>
        public string BrojNadmetanja { get; set; }
        /// <summary>
        /// Datum resenja žalbe
        /// </summary>
        public DateTime DatumResenja { get; set; }
        /// <summary>
        /// Broj rešenja
        /// </summary>
        public string BrojResenja { get; set; }
        /// <summary>
        /// Id tipa žalbe
        /// </summary>
        public Guid TipZalbeID { get; set; }
        /// <summary>
        /// ID statusa žalbe
        /// </summary>
        public Guid StatusZalbeID { get; set; }
        /// <summary>
        /// ID radnje na osnovu žalbe
        /// </summary>
        public Guid RadnjaNaOsnovuZalbeID { get; set; }
        /// <summary>
        /// Id podnosioca žalbe(kupca)
        /// </summary>
        public Guid PodnosilacZalbeID { get; set; }

    }
}
