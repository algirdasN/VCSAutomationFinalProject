using System;
using System.Collections.Generic;
using System.Text;

namespace VCSAutomationFinalProject
{
    class Brand
    {
        public static Brand Tactical511 = new Brand("5.11 Tactical", 0);
        public static Brand Bennon = new Brand("Bennon", 1);
        public static Brand EXC = new Brand("EXC", 2);
        public static Brand Garmont = new Brand("Garmont", 3);
        public static Brand HiTecMagnum = new Brand("Hi-Tec Magnum", 4);
        public static Brand MilTec = new Brand("Mil-Tec", 5);
        public static Brand Zamberlan = new Brand("Zamberlan", 6);
        public static Brand adidas = new Brand("adidas", 7);

        public string BrandName;
        public int Index;

        public Brand(string brandName, int index)
        {
            BrandName = brandName;
            Index = index;
        }
    }
}
