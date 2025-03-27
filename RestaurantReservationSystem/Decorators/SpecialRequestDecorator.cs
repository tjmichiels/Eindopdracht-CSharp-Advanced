using RestaurantReservationSystem.Models;

namespace RestaurantReservationSystem.Decorators;

public class SpecialRequestDecorator : ReservationDecorator
{
    private readonly string _specialRequest;

    public SpecialRequestDecorator(Reservation reservation, string specialRequest) : base(reservation)
    {
        _specialRequest = specialRequest;
    }

    public override string Details => $"{Reservation.Details}\nSPECIAL REQUEST: {_specialRequest}";
}