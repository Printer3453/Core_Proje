using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Portfolio
    {
        [Key]
        public int PortfolioID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string ProjectUrl { get; set; } = string.Empty;
        public string ImageUrl2 { get; set; } = string.Empty;
        public string Platform { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public bool Status { get; set; }
        public string Image1 { get; set; } = string.Empty;
        public string Image2 { get; set; } = string.Empty;
        public string Image3 { get; set; } = string.Empty;
        public string Image4 { get; set; } = string.Empty;
        public int Value { get; set; }

    }
}
