using ConsoleApp1.Models.DTOs;

namespace ConsoleApp1.Services;

public interface IVisitService
{
    Task<List<VisitDTO>> GetVisits(int Id);
    
}