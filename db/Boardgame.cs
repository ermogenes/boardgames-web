using System;
using System.Collections.Generic;

namespace boardgames_web.db
{
    public partial class Boardgame
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
        public string Designer { get; set; }
        public decimal Nota { get; set; }
        public string BggUrl { get; set; }
        public string ImgUrl { get; set; }
    }
}
