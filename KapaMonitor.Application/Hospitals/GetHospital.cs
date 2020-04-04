using KapaMonitor.Database;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KapaMonitor.Application.Hospitals
{
    public class GetHospital
    {
        private readonly ApplicationDbContext _context;

        public GetHospital(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<HospitalViewModel?> Do(int id)
        {
            var Hospital = await _context.Hospitals.FirstOrDefaultAsync(c => c.Id == id);

            if (Hospital == null)
                return null;

            return new HospitalViewModel(Hospital);
        }
    }
}
