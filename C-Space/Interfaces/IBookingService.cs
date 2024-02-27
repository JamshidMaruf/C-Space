namespace C_Space.Interfaces;

public interface IBookingService
{
    Booking Create(Booking booking);
    Booking Update(int id, Booking booking);
    bool Delete(int id);
    Booking GetById(int id);
    (string placeNumber, DateTime startTime, DateTime endTime) GetByUserId(int userId);
    List<Booking> GetAll();
}