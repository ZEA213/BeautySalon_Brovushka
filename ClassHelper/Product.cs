namespace BeautySalon_Brovushka.EF
{
    public partial class Product
    {
        public string GetImage
        {
            get
            {
                if (MainImagePath.Length > 0)
                {
                    return "/Photo/" + MainImagePath;
                }
                else return null;
            }
        }

        public string GetCost { get => Cost + " рублей"; }
        public string GetActive
        {
            get
            {
                if (IsActive)
                {
                    return null;
                }
                else return "Неактивен";
            }
        }

        public string GetColor
        {
            get
            {
                if (IsActive)
                {
                    return "White";
                }
                else return "LightGray";
            }
        }


    }
}