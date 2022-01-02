# Biggest Changes
* Updated to .NET6  
    * Incorporated Dependencies: BlazorInputFile, MudBlazor, and BouncyCastle
* Implement a Dark Theme with a Toggle
* Encapsulated Main Layout into MainLayout.Razor. This can be added to each page with one line to ensure a consistent UI. This can be added like:  
```razor
<MudLayout>
    <Client.Components.Public.Shared.MainLayout /> 
    <MudMainContent>
        Content will go here eventually
    </MudMainContent>
</MudLayout>
```
* Added History and Profile Page
* Added a Components folder that contains the Navbar and the Mainlayout. This can be a good place for us to store custom 
## Smaller Changes
* Made some minor refactors
* Changes to the Import page. This means less overall imports on each page within the client