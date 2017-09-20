using System;
using System.Collections.Generic;

namespace ASPNETCore01.Models
{
    public partial class TSeibetsu
    {
        public TSeibetsu()
        {
            TKojin = new HashSet<TKojin>();
        }

        public int Id { get; set; }
        public string ESeibetsu { get; set; }

        public virtual ICollection<TKojin> TKojin { get; set; }
    }
}
