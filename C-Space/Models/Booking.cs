namespace C_Space;

public class Booking
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int PlaceId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}
