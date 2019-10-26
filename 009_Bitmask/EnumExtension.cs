namespace _009_Bitmask
{
    public static class EnumExtension
    {
        // Colori secondari
        // OR operator per aggiungere nuovi flag
        const ColorEnum Orange = ColorEnum.Yellow | ColorEnum.Red;  // 0000_0100 OR 0000_1000 = 0000_1100 = 12
        const ColorEnum Green = ColorEnum.Yellow | ColorEnum.Blue;  // 0000_0100 OR 0001_0000 = 0001_0100 = 20
        const ColorEnum Violet = ColorEnum.Red | ColorEnum.Blue;    // 0000_1000 OR 0001_0000 = 0001_1000 = 24

        /// <summary>
        /// Fornisce una descrizione dell'enum ColorEnum.
        /// </summary>
        /// <param name="color">ColorEnum enum</param>
        /// <returns>string nome del colore</returns>
        public static string GetName(ColorEnum color)
        {
            switch (color)
            {
                case ColorEnum.Black: return "Nero";
                case ColorEnum.White: return "Bianco";
                case ColorEnum.Yellow: return "Giallo";
                case ColorEnum.Red: return "Rosso";
                case ColorEnum.Blue: return "Blu";

                case Orange: return "Arancione";
                case Green: return "Verde";
                case Violet: return "Viola";

                case (ColorEnum)22: return ("Verde chiaro");

                case ColorEnum.None:
                default: return "Colore sconosciuto!";
            }
        }
    }
}
