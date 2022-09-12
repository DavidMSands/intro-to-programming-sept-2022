using System;

public class CourseRegistrationManager
{

    public CourseRegistrationResponse RegisterForCourse(string? email, string? courseId, string? courseOfferingId)
    {
        var registered = !email.EndsWith("aol.com");
        return new CourseRegistrationResponse(Guid.NewGuid().ToString(), DateTime.Now.AddDays(15), registered);
    }

    public CourseRegistrationResponse RegisterForCourse(CourseRegistrationRequest request)
    {
        return RegisterForCourse(request.Email, request.CourseId, request.CourseOfferingId);
    }
}