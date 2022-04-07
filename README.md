# Transfer.Me
## An End to end Encrypted File Transfrer Website using Blazor Web Assembly and .NET
This is a project done by 3 Seniors at Oregon State University in 2021/2022. This is a year long project that started in September 2021 and ends in June 2022. The goal is to accomplish end to end encryption and provide the service to users in an intuitive way. The link to our live, hosted site is: [Transfer.Me](http://transferme.azurewebsites.net/)
### Website Features:
- End to End Encryption
- Allows users to upload a file, then encrypt and send to a users
- Senders are provided a Link and a key to access the file
- Recipients open the link sent by the sender, and input the key provided from the sender to download the file
- Interface is simplistic and has a dark / light theme. Both themes contain Orange (Go Beavs!) where light theme is Orange/White and Dark theme is Orange/Black

### Project Technologies / Libraries
#### <ins>Blazor Web Assembly<ins>
This project had a specific goal of using [Blazor WebAssembly](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor) (WASM). WASM is a technology that compiles code written in lower level languages to be runnable on the web. By compiling the code, the performance is nearly as good as it would be on a compiled local system. This means that.
- It takes slightly longer to load a web page
- Once the web page is loaded, everything runs extremely quickly  
  
This was an ideal technology for our project because encrypting a file can take time. By using web assembly there is almost no noticable wait time when encrypting a file since the performance is greatly improved by WASM. Another reason we decided to use Blazor WASM is because Blazor is a library that allows developers to use C# as the main development language, which meant we could write most of our project in C# and not have to maintain/learn multiple other languages!  

#### <ins>.NET6<ins>
We also used [.NET6](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-6) which is Microsoft's newest .NET platform. This contained critical updates to some of the Blazor syntax that made development easier and more intuitibe. With .NET6 we were able to use the features of ASP.NET to build our server code using C#, the same language we used to write our front end logic. Being able to write C# code throughout the main project was crucial to our success.
  
#### <ins>Azure Services<ins>
We used [Azure](https://azure.microsoft.com/en-us/) web services to deploy and host our web app. We were able to utilize the Azure App Service to see valuable data about our website statistics and configuration. We chose to deploy on Azure because we preferred to stick in the Microsoft realm. Since we used C#, .NET, and Visual Studio IDE, we were able to deploy our app to the cloud with a click of a button after the initial configuration.
  
#### <ins>Azure Cosmos DB<ins>
We chose to use Azure Cosmos DB because there was a trial period for students. Once we started using it, we found it was pretty intuitive and we were able to adapt to the NoSQL design with ease. We were still able to write SQL queries in our code to query the DB. To write to the DB, we serialized objects as JSON and it easily uploaded.  
  
#### <ins>BouncyCastle Cryptography Library<ins>
We opted to use the [BouncyCastle Cryptography Library](https://www.bouncycastle.org/csharp/index.html) because it appeared to be the most advanced and trusted cryptography libraries. There were several others that were viable options. But we found this one had the largest community, the most use, good documentation, and good support.  

#### <ins>MudBlazor<ins>
We used [MudBlazor](https://dev.mudblazor.com/) a component library built for Blazor. This library allowed us to develop our front end for our website with much more velocity than we previously expected. It also allowed us to easily add buttons, change our themes, and make incremental updates as we saw needed.
