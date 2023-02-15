
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TecherContext>(options => options.UseInMemoryDatabase("TeachersList"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/",()=> "Sample File");
app.MapGet("Products/{id}",async(int id,TecherContext tc)=>await tc.Techers.FindAsync(id));
app.MapPost("Products/add", async (Techer t, TecherContext tc) =>
{
    tc.Techers.Add(t);
    tc.SaveChanges();
});
app.MapPut("Products/update/{id}", async (int id,Techer t, TecherContext tc) =>
{
    var temp = await tc.Techers.FindAsync(id);
    if (temp is null) return Results.NotFound();
    temp.Id = t.Id;
    temp.Subject = t.Subject;
    temp.Name = t.Name;
    temp.Experience = t.Experience;
    await tc.SaveChangesAsync();
    return Results.NoContent();
});
app.MapDelete("Products/Delete/{id}", async (int id, TecherContext tc) =>
{
    if (await tc.Techers.FindAsync(id) is Techer t)
    {
        tc.Techers.Remove(t);
        await tc.SaveChangesAsync();
        return Results.Ok(t);
    }
    return Results.NotFound();
});

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};



app.Run();


class Techer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Subject { get; set; }
    public string Experience { get; set; }
}

class TecherContext : DbContext
{
    public TecherContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Techer> Techers { get; set; }
}
