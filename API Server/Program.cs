using Microsoft.AspNetCore.Authorization.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();
StudentData data = new();

app.MapGet("/", () => "Nothing");
app.MapGet("/hello", () => "Goodbye!");
app.MapGet("/students/{number}", data.GetStudent);

app.MapPost("/students", data.PostStudent);

app.Urls.Add("http://*:5140/");

app.Run();
class StudentData
{
    List<Student> student = new()
    {
        new Student() {Name = "Elias", HitPoints = 100},
        new Student() {Name = "Burgir", HitPoints = 101},
        new Student() {Name = "Kebab", HitPoints = 102}

    };



    public IResult PostStudent()
    {
        Console.WriteLine("Hurray");
        return Results.Ok();
    }

    public IResult GetStudent(int number)
    {


        if (number < 0 || number >= student.Count)
        {
            return Results.NotFound();
        }

        return Results.Ok(student[number]);
    }
}
