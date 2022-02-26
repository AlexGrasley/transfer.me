namespace Client
{
    public class Drawer
    {
        private bool _drawerOpen;

        public bool DrawerOpen
        {
            get => _drawerOpen;
            set => _drawerOpen = value;
        }

        public Drawer()
        {
            _drawerOpen = true;
        }


        public void DrawerToggle()
        {
            DrawerOpen = !DrawerOpen;
        }
    }
}
