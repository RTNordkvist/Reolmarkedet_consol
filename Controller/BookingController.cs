using Reolmarkedet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reolmarkedet.Controller
{
    public class BookingController
    {
        private DbContext _dbContext;

        public BookingController(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateBooking(DateTime startDate, DateTime endDate, int tenantId, int boothId)
        {
            var booking = new Booking();
            booking.startDate = startDate;
            booking.endDate = endDate;
            booking.TenantId = tenantId;
            booking.BoothId = boothId;

            var id = _dbContext.BookingDb.AddItem(booking);

            _dbContext.BookingDb.Items.FirstOrDefault(x => x.Id == id).BookingNo = id + 10000000;

            _dbContext.BookingDb.UpdateDatabase();
        }

        public List<Booth> GetAvailableBooths(DateTime startDate, DateTime endDate)
        {
            if (_dbContext.BookingDb.Items != null)
            {
                //TODO: Filtrér på startDate og endDate

                return _dbContext.BoothDb.Items;
            }
            else
            {
                return _dbContext.BoothDb.Items;
            }
        }
    }
}
