namespace Client.Code
{
    public class Drawer
    {

        public Drawer() { }

        public bool _drawerOpen = true;

        public void DrawerToggle()
        {
            this._drawerOpen = !this._drawerOpen;
        }
    }

}
