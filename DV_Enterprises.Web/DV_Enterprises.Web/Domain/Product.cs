using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DV_Enterprises.Web.Domain
{
    public partial class Product
    {
        public List<Image> Images { get; set; }

        public Image Photo { get { return Images.First; } }
        public string PhotoPath { get { return Photo.Path; } }
        public string PhotoCaption { get { return Photo.Caption; } }
    }
}
