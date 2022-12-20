using Poems.Models;
using Poems.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<global::Poems.Models.DbContext>();
builder.Services.AddScoped<IRepository<Poem>, PoemsRepository>();
builder.Services.AddScoped<IRepository<Author>, AuthorsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute("index", "{controller=IndexPage}/{action=Show}");
app.MapControllerRoute("poem", "PoemPage/{poemId}", new {action = "Show", controller="PoemPage"});
app.MapControllerRoute("search", "IndexPage/{authorId}", new {action = "SearchByAuthor", controller = "IndexPage"});

app.UseAuthorization();

app.Run();