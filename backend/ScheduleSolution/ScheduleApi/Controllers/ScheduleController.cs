
using ScheduleApi.Adapters;

namespace ScheduleApi.Controllers;

[Route("schedule")]
public class ScheduleController : ControllerBase
{
    private readonly ScheduleAdapter _adapter;

    public ScheduleController(ScheduleAdapter adapter)
    {
        _adapter = adapter;
    }
    // GET /schedule/938983983hsdjfh

    [HttpGet("{courseId}")]
    public async Task<ActionResult<ScheduleResponse>> GetCourseById(string courseId)
    {
        var adapter = new ScheduleAdapter();
        var data = adapter.GetForClass(courseId);
        if (data ==null)
        {
            return NotFound();
        }
        //var response = NotFound();     //This is bad need to fix.
        var response = new ScheduleResponse() { CourseId = courseId };

        //var response = new ScheduleResponse();

        //response.Data.Add(new ScheduleItem { StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(3) });
        return Ok(response);
    }
}



public record ScheduleItem
{
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; set; }
}

public record ScheduleResponse
{
    public List<ScheduleItem> Data { get; init; } = new List<ScheduleItem>();
    public string CourseId { get; init; } = string.Empty;

   
}