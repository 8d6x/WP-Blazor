//using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorWPBlog.UI;
using BlazorWPBlog.UI.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using WordPressPCL;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var wpApiEndpoint = builder.Configuration["WP_Endpoint"];
var client = new WordPressClient(wpApiEndpoint);
builder.Services.AddSingleton(client);

builder.Services.AddSingleton<ITagService, TagService>();
builder.Services.AddSingleton<ICategoryService, CategoryService>();
builder.Services.AddAntDesign();


await builder.Build().RunAsync();
