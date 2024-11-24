using PurpleBuzz.BL.Services.Abstractions;
using PurpleBuzz.DAL.Models;
using PurpleBuzz.DAL.Contexts;
namespace PurpleBuzz.BL.Services.Concretes;

public class OurServiceService : IOurServiceService
{
    private readonly PurpleBuzzDbContext _context;

    public OurServiceService(PurpleBuzzDbContext context)
    {
        _context = context;
    }

    public IEnumerable<OurService> GetOurServices()
    {
        return _context.OurServices.ToList();
    } 
}