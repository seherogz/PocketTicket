using PocketTicket.Data.Base;
using PocketTicket.Models;

namespace PocketTicket.Data.Services
{
    public class ReservationsService : EntityBaseRepository<Reservation>, IReservationsService//bu class dbcontext e bağımlı
    {
        readonly AppDbContext _context;

        public ReservationsService(AppDbContext context) : base(context)//dependency inversion
                                                                   //burda kullandığım base miras aldığım class yani EntityBaseRepository.
                                                                   //base class parant class ile iletişim için kullanıyoruz.
        {
            _context = context;
        }
    }
}
