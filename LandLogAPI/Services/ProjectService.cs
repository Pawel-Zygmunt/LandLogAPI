using AutoMapper;
using LandLogAPI.Entities;

namespace LandLogAPI.Services
{
    public interface IProjectService
    {

    }

    public class ProjectService : IProjectService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProjectService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
    }
}
