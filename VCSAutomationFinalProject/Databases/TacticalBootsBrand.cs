namespace VCSAutomationFinalProject.Databases
{
    class TacticalBootsBrand
    {
        public static TacticalBootsBrand Tactical511 = new TacticalBootsBrand("5.11 Tactical", 0);
        public static TacticalBootsBrand Bennon = new TacticalBootsBrand("Bennon", 1);
        public static TacticalBootsBrand EXC = new TacticalBootsBrand("EXC", 2);
        public static TacticalBootsBrand Garmont = new TacticalBootsBrand("Garmont", 3);
        public static TacticalBootsBrand HiTecMagnum = new TacticalBootsBrand("Hi-Tec Magnum", 4);
        public static TacticalBootsBrand MilTec = new TacticalBootsBrand("Mil-Tec", 5);
        public static TacticalBootsBrand Zamberlan = new TacticalBootsBrand("Zamberlan", 6);
        public static TacticalBootsBrand adidas = new TacticalBootsBrand("adidas", 7);

        public string BrandName;
        public int Index;

        private TacticalBootsBrand(string brandName, int index)
        {
            BrandName = brandName;
            Index = index;
        }
    }
}
