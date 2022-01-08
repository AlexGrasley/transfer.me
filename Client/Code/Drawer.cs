namespace Client.Code
{
    public class Drawer
    {

        public Drawer() { }

        public bool _drawerOpen = true;

        public void DrawerToggle()
        {
            _drawerOpen = !_drawerOpen;
        }
    }
}

