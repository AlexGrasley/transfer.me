using Client.Themes;

namespace Client
{
    public partial class MainLayout
    {
        public Theme ?MyTheme { get; set; }

        protected override void OnInitialized()
        {
            MyTheme = new Theme();
        }
    }
}
