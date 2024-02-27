using C_Space.Interfaces;
using C_Space.Models;

namespace C_Space.Services;

public class PlaceService : IPlaceService
{
    private List<Place> places;
    public PlaceService()
    {
        places = new List<Place>();
    }

    public Place Create(Place place)
    {
        var existPlace = places.FirstOrDefault(x => x.Number == place.Number);
        if (existPlace is not null)
            throw new Exception("This place already exists");

        places.Add(place);
        return place;
    }

    public bool Delete(int id)
    {
        var user = places.FirstOrDefault(x => x.Id == id);
        if (user is null)
            throw new Exception("This place is not found");

        return places.Remove(user);
    }

    public List<Place> GetAll() => places;

    public List<Place> GetAvailablePlaceList()
    {
        var res = new List<Place>();
        foreach (var place in places)
        {
            if (place.IsAvailable)
            {
                res.Add(place);
            }
        }
        return res;
    }

    public Place GetById(int id)
    {
        var place = places.FirstOrDefault(place => place.Id == id);
        if (place is null)
            throw new Exception("This place is not found");

        return place;
    }

    public Place Update(int id, Place place)
    {
        var existPlace = places.FirstOrDefault(place => place.Id == id);
        if (existPlace is null)
            throw new Exception("This place is not found");

        existPlace.Id = id;
        existPlace.Room = place.Room;
        existPlace.Price = place.Price;
        existPlace.Floor = place.Floor;
        existPlace.Number = place.Number;
        existPlace.Features = place.Features;
        existPlace.IsAvailable = place.IsAvailable;

        return existPlace;
    }
}