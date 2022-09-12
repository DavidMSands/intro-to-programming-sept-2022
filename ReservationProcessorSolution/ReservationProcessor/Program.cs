// See https://aka.ms/new-console-template for more information

//Console.WriteLine("Register for a Course");

//Console.Write("Enter your email: ");
//string? email = Console.ReadLine();

//Console.Write("Enter your esired Course ID: ");
//string? courseId = Console.ReadLine();

//Console.Write("Enter your Offering ID: ");
//string? offeringId = Console.ReadLine();


//Console.WriteLine($"Thank you for registering with email address: \"{email}\" for course {courseId} and offering {offeringId}.");
//CourseRegistrationManager couurseRegistrationManager = new CourseRegistrationManager();

//CourseRegistrationRequest request = new CourseRegistrationRequest(email, courseId, courseOfferingId);

//CourseRegistrationResponse response = couurseRegistrationManager.RegisterForCourse(email, courseId, offeringId);

//if(response.IsRegistered)
//{
//    Console.WriteLine("Congratulations! You have been registered!");
//    Console.WriteLine($"Your Registration Id is {response.Id}");
//    Console.WriteLine($"The course starts on {response.courseDate:d}");
//}
//else
//{
//    Console.WriteLine("Sorry, you are not registered for the course!");
//}

using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder();

builder.Services.AddScoped<CourseRegistrationManager>();

var app = builder.Build();

app.MapPost("/registrations", (
    [FromBody] CourseRegistrationRequest request,
    [FromServices] CourseRegistrationManager manager) =>
{
    var response = manager.RegisterForCourse(request);
    if (response.IsRegistered)
    {
        return Results.Ok(response);
    }
    else
    {
        return Results.BadRequest(response);
    }
});


Console.WriteLine("Fixing to run your web application!");
app.Run();
Console.WriteLine("Done running your web application!");