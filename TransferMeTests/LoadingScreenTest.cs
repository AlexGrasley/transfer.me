using NUnit.Framework;
using Bunit;
using Client.Components;

namespace TransferMeTests
{
    public class LoadingScreenTest
    {
        [Test]
        public void Setup()
        {
            //setup
            using var ctx = new Bunit.TestContext();
            //build component
            var FileInfoDialogComponent = ctx.RenderComponent<LoadingScreen>();
            //Assert equal;
            FileInfoDialogComponent.MarkupMatches("<center><div style=\"position:absolute; top:30vh; width:100%; text-align:center\"><p class=\"mud-typography mud-typography-body1 mud-primary-text\" style=\"font-size:25px; padding-bottom:2%\">Please Wait...</p><div style=\"display:flex; gap:10px; justify-content:center; align-items:center\"><div class=\"mud-progress-circular mud-primary-text mud-progress-medium mud-progress-indeterminate\" role=\"progressbar\" style=\"transform:rotate(-90deg);height:70px;width:70px;;\" aria-valuenow=\"0\"><svg class=\"mud-progress-circular-svg\" viewBox=\"22 22 44 44\"><circle class=\"mud-progress-circular-circle mud-progress-indeterminate\" cx=\"44\" cy=\"44\" r=\"20\" fill=\"none\" stroke-width=\"3\"></circle></svg></div></div></div></center>");
        }
    }
}