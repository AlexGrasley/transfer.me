using MudBlazor;

namespace Client.Themes
{
    public class Theme
    {
        public bool IsDarkTheme { get; set; } = false;
        public MudTheme CurrentTheme = new MudTheme();

        public void ToggleDarkTheme()
        {
            IsDarkTheme = !IsDarkTheme;
            if (IsDarkTheme)
            {
                CurrentTheme = GenerateDarkTheme();
            }
            else
            {
                CurrentTheme = GenerateLightTheme();
            }
        }

        private MudTheme GenerateDarkTheme()
        {
            var DTheme = new MudTheme
            {
                Palette = new Palette()
                {
                    Black = "#27272f",
                    Background = "#32333d",
                    BackgroundGrey = "#27272f",
                    Primary = "#DC4405",
                    Secondary = "#000000",
                    Surface = "#373740",
                    TextPrimary = "#FFFFFF",
                    TextSecondary = "rgba(255,255,255, 0.50)"
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
                    Secondary = "#FFFFFF",
                    Surface = "#373740",
                    TextPrimary = "#000000",
                    TextSecondary = "rgba(255,255,255, 0.50)"
                }
            };
            return LTheme;
        }
    }
}
