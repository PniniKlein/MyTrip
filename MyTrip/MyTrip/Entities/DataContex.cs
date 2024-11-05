
using MyTrip.Entities;

public class DataContex
{
    public List<User> users = new List<User>();
    public List<Trip> trips = new List<Trip>();
    public List<Attraction> attractions = new List<Attraction>();
    public List<AttractionToTrip> attractionToTrips = new List<AttractionToTrip>();
    public List<Guide> guides = new List<Guide>();
    public List<Order> orders = new List<Order>();
}