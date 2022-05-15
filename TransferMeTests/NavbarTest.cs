using NUnit.Framework;
using Bunit;
using Client.Components;

namespace TransferMeTests
{
    public class NavbarTest
    {
        [Test]
        public void Setup()
        {
            //setup
            using var ctx = new Bunit.TestContext();
            //build component
            var FileInfoDialogComponent = ctx.RenderComponent<Navbar>();
            //Assert equal;
            FileInfoDialogComponent.MarkupMatches("<div class=\"mud-paper mud-paper-square mud-elevation-1 py-3\" style=\"height:100%;width:100%;background-color: #B0B3B8;border:solid; border-color:darkgray; border-width:1px; border-top:none; border-left:none;\"><div class=\"mud-navmenu mud-navmenu-default mud-navmenu-margin-none\" style=\"background-color:#B0B3B8\"><h6 class=\"mud-typography mud-typography-h6 mud-inherit-text px-4\">Menu</h6><div class=\"mud-list mud-list-padding\"><div tabindex=\"0\" class=\"mud-list-item mud-list-item-gutters\"  ><div class=\"mud-list-item-text \"><p class=\"mud-typography mud-typography-body1 mud-inherit-text\"></p><div class=\"mud-nav-item mud-ripple\"><a  href=\"/\" rel=\"\" class=\"mud-nav-link active\"><div class=\"mud-nav-link-text\">Home</div></a></div><p></p></div></div><div tabindex=\"0\" class=\"mud-list-item mud-list-item-gutters\"  ><div class=\"mud-list-item-text \"><p class=\"mud-typography mud-typography-body1 mud-inherit-text\"></p><div id=\"linkDownload\" class=\"mud-nav-item mud-ripple\"><a  href=\"/download\" rel=\"\" class=\"mud-nav-link\"><div class=\"mud-nav-link-text\">Download</div></a></div><p></p></div></div><div tabindex=\"0\" class=\"mud-list-item mud-list-item-gutters\"  ><div class=\"mud-list-item-text \"><p class=\"mud-typography mud-typography-body1 mud-inherit-text\"></p><div id=\"linkProfile\" class=\"mud-nav-item mud-ripple\"><a  href=\"/Profile\" rel=\"\" class=\"mud-nav-link\"><div class=\"mud-nav-link-text\">Profile</div></a></div><p></p></div></div><div tabindex=\"0\" class=\"mud-list-item mud-list-item-gutters\"  ><div class=\"mud-list-item-text \"><p class=\"mud-typography mud-typography-body1 mud-inherit-text\"></p><div id=\"linkAbout\" class=\"mud-nav-item mud-ripple\"><a  href=\"/about\" rel=\"\" class=\"mud-nav-link\"><div class=\"mud-nav-link-text\">About</div></a></div><p></p></div></div></div></div></div>");
        }
    }
}