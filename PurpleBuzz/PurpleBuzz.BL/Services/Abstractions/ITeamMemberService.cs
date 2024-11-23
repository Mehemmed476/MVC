using PurpleBuzz.DAL.Models;

namespace PurpleBuzz.BL.Services.Abstractions;

public interface ITeamMemberService
{
    Task AddTeamMember(TeamMember teamMember);
    Task<List<TeamMember>> GetAllTeamMembersAsync();
    Task<TeamMember> GetTeamMemberAsync(int teamMemberId);
    Task SoftDeleteTeamMemberAsync(int id);
    Task RestoreTeamMemberAsync(int id);
    Task DeleteTeamMemberAsync(int id);
    Task UpdateTeamMemberAsync(TeamMember teamMember);
    
}

