using MudBlazor;

namespace Client.Themes
{
    public class Theme
    {
        public bool IsDarkTheme { get; set; } = false;
        public MudTheme CurrentTheme = new MudTheme();

        public Theme()
        {
            
            if (IsDarkTheme)
            {
                CurrentTheme = GenerateDarkTheme();
            }
            else
            {
                CurrentTheme = GenerateLightTheme();
            }
            
        }

        public void ToggleDarkTheme()
        {
            IsDarkTheme = !IsDarkTheme;
            CurrentTheme = IsDarkTheme
                ? GenerateDarkTheme()
                : GenerateLightTheme();
        }

        private MudTheme GenerateDarkTheme()
        {
            var DTheme = new MudTheme
            {
                Palette = new Palette()
                {
                    Black = "#27272f",
                    Background = "#181818",
                    BackgroundGrey = "#000000",
                    Primary = "#DC4405",
                    Secondary = "#181818",
                    Tertiary = "#FFFFFF",
                    Surface = "#373740",
                    TextPrimary = "#FFFFFF",
                    TextSecondary = "rgba(255,255,255, 0.50)",
                    ActionDisabledBackground = "#4A4A4A",
                    ActionDisabled = "#DC4405",
                    

                }
            };
            return DTheme;
        }

        private MudTheme GenerateLightTheme()
        {
            var LTheme = new MudTheme
            {
                Palette = new Palette()
                {
                    Primary = "#DC4405",
                    Background = "#FFFFFF",
                    Secondary = "#FFFFFF",
                    Surface = "#373740",
                    Tertiary = "#181818",
                    TextPrimary = "#000000",
                    TextSecondary = "rgba(255,255,255, 0.50)",
                    ActionDisabledBackground = "#BEBEBE",
                    ActionDisabled = "#DC4405"
                }
            };
            return LTheme;
        }
    }
}
