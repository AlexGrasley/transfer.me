using Client.Themes;

namespace Client
{
    public partial class MainLayout
    {
        public Theme? MyTheme { get; set; }

        protected async override Task OnInitializedAsync()
        {
            MyTheme = new Theme();
        }
    }
}
