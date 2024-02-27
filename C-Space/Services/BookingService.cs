using C_Space.Interfaces;
using C_Space.Models;

namespace C_Space.Services;

public class BookingService : IBookingService
{
    private readonly List<Booking> bookings;
    private readonly UserService userService;
    private readonly PlaceService placeService;
    public BookingService(PlaceService placeService, UserService userService)
    {
        this.bookings = new List<Booking>();
        this.placeService = placeService;
        this.userService = userService;
    }

    public Booking Create(Booking booking)
    {
        var user = userService.GetById(booking.UserId);

        var place = placeService.GetById(booking.PlaceId);
        if (!place.IsAvailable)
            throw new Exception("This place is not available");

        place.IsAvailable = false;
        bookings.Add(booking);
        return booking;
    }

    public bool Delete(int id)
    {
        var booking = bookings.FirstOrDefault(x => x.Id == id);
        if (booking is null)
            throw new Exception("This booking is not found");

        return bookings.Remove(booking);
    }

    public List<Booking> GetAll()
    {
        return bookings;
    }

    public Booking GetById(int id)
    {
        var booking = bookings.FirstOrDefault(x => x.Id == id);
        if (booking is null)
            throw new Exception("This booking is not found");

        return booking;
    }

    public (string placeNumber, DateTime startTime, DateTime endTime) GetByUserId(int userId)
    {
        var user = userService.GetById(userId);

        var booking = bookings.FirstOrDefault(booking => booking.UserId == userId);
        if (booking is null)
            throw new Exception("This booking is not found");

        var place = placeService.GetById(booking.PlaceId);

        return (placeNumber: place.Number, startTime: booking.StartTime, endTime: booking.EndTime);
    }

    public Booking Update(int id, Booking booking)
    {
        var existBooking = bookings.FirstOrDefault(x => x.Id == id);
        if (existBooking is null)
            throw new Exception("This booking is not found");

        existBooking.Id = id;
        existBooking.UserId = booking.UserId;
        existBooking.PlaceId = booking.PlaceId;
        existBooking.StartTime = booking.StartTime;
        existBooking.EndTime = booking.EndTime;

        return existBooking;
    }
}