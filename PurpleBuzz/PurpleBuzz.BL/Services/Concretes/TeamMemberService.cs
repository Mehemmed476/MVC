using Microsoft.EntityFrameworkCore;
using PurpleBuzz.BL.Services.Abstractions;
using PurpleBuzz.DAL.Contexts;
using PurpleBuzz.DAL.Models;

namespace PurpleBuzz.BL.Services.Concretes;

public class TeamMemberService : ITeamMemberService
{
    private readonly PurpleBuzzDbContext _context;

    public TeamMemberService(PurpleBuzzDbContext context)
    {
        _context = context;
    }
    
    
    public async Task AddTeamMember(TeamMember teamMember)
    {
        teamMember.CreatedDate = DateTime.Now;
        await _context.TeamsMembers.AddAsync(teamMember);
        await _context.SaveChangesAsync();
    }

    public async Task<List<TeamMember>> GetAllTeamMembersAsync()
    {
        List<TeamMember>? teamMembers = await _context.TeamsMembers.ToListAsync();
       
        if (teamMembers == null)
        {
            throw new NullReferenceException();
        }
        
        return teamMembers;
    }

    public async Task<TeamMember> GetTeamMemberAsync(int teamMemberId)
    {
        TeamMember? teamMember = await _context.TeamsMembers.FindAsync(teamMemberId);

        if (teamMember == null)
        {
            throw new NullReferenceException();
        }
        
        return teamMember;
    }

    public async Task SoftDeleteTeamMemberAsync(int id)
    {
        TeamMember? searchTeamMember = await _context.TeamsMembers.FindAsync(id); 
        
        if (searchTeamMember == null)
        {
            throw new NullReferenceException();
        }
        
        searchTeamMember.IsDeleted = true;
        searchTeamMember.DeletedDate = DateTime.Now;
        _context.TeamsMembers.Update(searchTeamMember);
        await _context.SaveChangesAsync();
    }

    public async Task RestoreTeamMemberAsync(int id)
    {
        TeamMember? searchTeamMember = await _context.TeamsMembers.FindAsync(id); 
        
        if (searchTeamMember == null)
        {
            throw new NullReferenceException();
        }
        
        searchTeamMember.IsDeleted = false;
        searchTeamMember.DeletedDate = null;
        _context.TeamsMembers.Update(searchTeamMember);
        await _context.SaveChangesAsync(); 
    }

    public async Task DeleteTeamMemberAsync(int id)
    {
        TeamMember? searchTeamMember = await _context.TeamsMembers.FindAsync(id); 
        
        if (searchTeamMember == null)
        {
            throw new NullReferenceException();
        }
        
        _context.TeamsMembers.Remove(searchTeamMember);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTeamMemberAsync(TeamMember teamMember)
    {
        TeamMember? searchTeamMember = await _context.TeamsMembers.FindAsync(teamMember.Id);
        
        if (searchTeamMember == null)
        {
            throw new ArgumentException("Team member not found.");
        }
       teamMember.ModifiedDate = DateTime.Now;
        _context.Entry(searchTeamMember).CurrentValues.SetValues(teamMember);
        await _context.SaveChangesAsync();
    }
}