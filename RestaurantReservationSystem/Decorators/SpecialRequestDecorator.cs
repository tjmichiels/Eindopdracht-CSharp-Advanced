using RestaurantReservationSystem.Models;

namespace RestaurantReservationSystem.Decorators;

public class SpecialRequestDecorator : ReservationDecorator
{
    private readonly Reservation _reservation;
    private readonly string _specialRequest;

    public SpecialRequestDecorator(Reservation reservation, string specialRequest) : base(reservation)
    {
        _reservation = reservation;
        _specialRequest = specialRequest;

        Id = _reservation.Id;
        GuestName = _reservation.GuestName;
        DateTime = _reservation.DateTime;
        NumberOfGuests = _reservation.NumberOfGuests;
        ReservationState = _reservation.ReservationState;
        ReservationType = _reservation.ReservationType;
        ReservedTable = _reservation.ReservedTable;
    }

    public override string Details => $"{Reservation.Details}\nSPECIAL REQUEST: {_specialRequest}";
}