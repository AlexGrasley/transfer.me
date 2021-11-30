using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MudBlazor.Services;

namespace TransferMe.Client.Code
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
