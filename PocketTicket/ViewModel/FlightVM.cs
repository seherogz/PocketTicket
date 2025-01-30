using PocketTicket.Data;

namespace PocketTicket.ViewModel;

public class FlightVM
{
    public int Id { get; set; }
    public string Airline { get; set; }
    public string FlightNumber { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public decimal Price { get; set; }
    public FlightStatus Status { get; set; }
    public int DepartureAirportId { get; set; }
    public int ArrivalAirportId { get; set; }
}
