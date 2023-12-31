using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agrainexus.Data.Models
{
    public class Farm
    {
        public int Id { get; set; }
        public string? NickName { get; set; }
        public string? Location { get; set; }
        public string? Crops { get; set; }
        public string? Area { get; set; }
        public string? AreaUnits { get; set; }
        public int UserId { get; set; }
    }
}
