using PurpleBuzz.DAL.Models;

namespace PurpleBuzz.BL.Services.Abstractions;

public interface IOurServiceService
{
    IEnumerable<OurService> GetOurServices(); 
}