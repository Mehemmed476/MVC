using Microsoft.EntityFrameworkCore;
using PurpleBuzz.BL.Services.Abstractions;
using PurpleBuzz.DAL.Contexts;
using PurpleBuzz.DAL.Models;

namespace PurpleBuzz.BL.Services.Concretes;

public class WorkService : IWorkService
{
    private readonly PurpleBuzzDbContext _context;

    public WorkService(PurpleBuzzDbContext context)
    {
        _context = context;
    }

    public async Task AddWork(Work work)
    {
        work.CreatedDate = DateTime.Now;
        await _context.Works.AddAsync(work);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Work>> GetAllWorksAsync()
    {
        List<Work>? works = await _context.Works.ToListAsync();
       
        if (works == null)
        {
            throw new NullReferenceException();
        }
        
        return works;
    }

    public async Task<Work> GetWorkAsync(int id)
    {
        Work? work = await _context.Works.FindAsync(id);

        if (work == null)
        {
            throw new NullReferenceException();
        }
        
        return work; 
    }

    public async Task SoftDeleteWorkAsync(int id)
    {
        Work? searchWork = await _context.Works.FindAsync(id); 
        
        if (searchWork == null)
        {
            throw new NullReferenceException();
        }
        
        searchWork.IsDeleted = true;
        searchWork.DeletedDate = DateTime.Now;
        _context.Works.Update(searchWork);
        await _context.SaveChangesAsync();
    }

    public async Task RestoreWorkAsync(int id)
    {
        Work? searchWork = await _context.Works.FindAsync(id); 
        
        if (searchWork == null)
        {
            throw new NullReferenceException();
        }
        
        searchWork.IsDeleted = false;
        searchWork.DeletedDate = null;
        _context.Works.Update(searchWork);
        await _context.SaveChangesAsync();  
    }

    public async Task DeleteWorkAsync(int id)
    {
        Work? searchWork = await _context.Works.FindAsync(id); 
        
        if (searchWork == null)
        {
            throw new NullReferenceException();
        }
        
        _context.Works.Remove(searchWork);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateWorkAsync(Work work)
    {
        Work? searchWork = await _context.Works.FindAsync(work.Id);
        
        if (searchWork == null)
        {
            throw new ArgumentException("Team member not found.");
        }
        work.ModifiedDate = DateTime.Now;
        _context.Entry(searchWork).CurrentValues.SetValues(work);
        await _context.SaveChangesAsync(); 
    }
}