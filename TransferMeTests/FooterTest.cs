using NUnit.Framework;
using Bunit;
using Client.Components;

namespace TransferMeTests
{
    public class FooterTest
    {
        [Test]
        public void Setup()
        {
            //setup
            using var ctx = new Bunit.TestContext();
            //build component
            var FooterComponent = ctx.RenderComponent<Footer>();

            //Assert equal;
            FooterComponent.MarkupMatches("<footer ><center ><div class=\"footerContent\" ><div class=\"row\" ><div class=\"column left\" ><p class=\"mud-typography mud-typography-body1 mud-secondary-text\" style=\"font-size: 1.0rem\">License</p><a aria-label=\"github\"  type=\"button\" href=\"https://github.com/AlexGrasley/Transfer.me/blob/main/LICENSE.md\" class=\"mud-button-root mud-icon-button mud-icon-button-color-secondary mud-ripple mud-ripple-icon\" ><span class=\"mud-icon-button-label\"><svg class=\"mud-icon-root mud-svg-icon mud-inherit-text mud-icon-size-medium\" focusable=\"false\" viewBox=\"0 0 24 24\" aria-hidden=\"true\"><g><rect fill=\"none\" height=\"24\" width=\"24\"></rect></g><g><path d=\"M22,3l-1.67,1.67L18.67,3L17,4.67L15.33,3l-1.66,1.67L12,3l-1.67,1.67L8.67,3L7,4.67L5.33,3L3.67,4.67L2,3v16 c0,1.1,0.9,2,2,2l16,0c1.1,0,2-0.9,2-2V3z M11,19H4v-6h7V19z M20,19h-7v-2h7V19z M20,15h-7v-2h7V15z M20,11H4V8h16V11z\"></path></g></svg></span></a></div><div class=\"column middle\" ><p class=\"mud-typography mud-typography-body1 mud-secondary-text\" style=\"font-size: 1.0rem\">Source Code</p><a aria-label=\"github\"  type=\"button\" href=\"https://github.com/AlexGrasley/Transfer.me\" class=\"mud-button-root mud-icon-button mud-icon-button-color-secondary mud-ripple mud-ripple-icon\" ><span class=\"mud-icon-button-label\"><svg class=\"mud-icon-root mud-svg-icon mud-inherit-text mud-icon-size-medium\" focusable=\"false\" viewBox=\"0 0 24 24\" aria-hidden=\"true\"><path d=\"M12 .3a12 12 0 0 0-3.8 23.4c.6.1.8-.3.8-.6v-2c-3.3.7-4-1.6-4-1.6-.6-1.4-1.4-1.8-1.4-1.8-1-.7.1-.7.1-.7 1.2 0 1.9 1.2 1.9 1.2 1 1.8 2.8 1.3 3.5 1 0-.8.4-1.3.7-1.6-2.7-.3-5.5-1.3-5.5-6 0-1.2.5-2.3 1.3-3.1-.2-.4-.6-1.6 0-3.2 0 0 1-.3 3.4 1.2a11.5 11.5 0 0 1 6 0c2.3-1.5 3.3-1.2 3.3-1.2.6 1.6.2 2.8 0 3.2.9.8 1.3 1.9 1.3 3.2 0 4.6-2.8 5.6-5.5 5.9.5.4.9 1 .9 2.2v3.3c0 .3.1.7.8.6A12 12 0 0 0 12 .3\"></path></svg></span></a></div><div class=\"column right\" ><p class=\"mud-typography mud-typography-body1 mud-secondary-text\" style=\"font-size: 1.0rem\">About</p><a aria-label=\"github\"  type=\"button\" href=\"/about\" class=\"mud-button-root mud-icon-button mud-icon-button-color-secondary mud-ripple mud-ripple-icon\" ><span class=\"mud-icon-button-label\"><svg class=\"mud-icon-root mud-svg-icon mud-inherit-text mud-icon-size-medium\" focusable=\"false\" viewBox=\"0 0 24 24\" aria-hidden=\"true\"><g><rect fill=\"none\" height=\"24\" width=\"24\"></rect></g><g><path d=\"M11.07,12.85c0.77-1.39,2.25-2.21,3.11-3.44c0.91-1.29,0.4-3.7-2.18-3.7c-1.69,0-2.52,1.28-2.87,2.34L6.54,6.96 C7.25,4.83,9.18,3,11.99,3c2.35,0,3.96,1.07,4.78,2.41c0.7,1.15,1.11,3.3,0.03,4.9c-1.2,1.77-2.35,2.31-2.97,3.45 c-0.25,0.46-0.35,0.76-0.35,2.24h-2.89C10.58,15.22,10.46,13.95,11.07,12.85z M14,20c0,1.1-0.9,2-2,2s-2-0.9-2-2c0-1.1,0.9-2,2-2 S14,18.9,14,20z\"></path></g></svg></span></a></div></div></div></center></footer>");
        }
    }
}