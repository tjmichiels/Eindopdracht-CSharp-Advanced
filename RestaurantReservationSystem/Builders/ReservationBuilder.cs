using RestaurantReservationSystem.Enums;
using RestaurantReservationSystem.Models;
using RestaurantReservationSystem.States;

namespace RestaurantReservationSystem.Builders;

public class ReservationBuilder
{
    private readonly Reservation _reservation = new Reservation();

    public ReservationBuilder SetGuestName(string name)
    {
        _reservation.Name = name;
        return this;
    }

    public ReservationBuilder SetDateTime(DateTime dateTime)
    {
        _reservation.DateTime = dateTime;
        return this;
    }

    public ReservationBuilder SetNumberOfGuests(int numberOfGuests)
    {
        _reservation.NumberOfGuests = numberOfGuests;
        return this;
    }

    public ReservationBuilder SetDetails(string details)
    {
        _reservation.Details = details;
        return this;
    }

    public Reservation Build()
    {
        _reservation.ReservationState = new NewReservationState();
        return _reservation;
    }
    
}