using RestaurantReservationSystem.Models;

namespace RestaurantReservationSystem.Decorators;

public class ReservationDecorator : Reservation
{
    protected Reservation Reservation;

    protected ReservationDecorator(Reservation reservation)
    {
        Reservation = reservation;
    }
    
    public override string Details => Reservation.Details;
}