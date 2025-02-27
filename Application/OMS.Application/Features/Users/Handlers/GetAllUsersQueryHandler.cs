using AutoMapper;
using OMS.Application.Features.Users.Dtos;
using OMS.Application.Features.Users.Queries;
using OMS.Application.Features.Base;
using OMS.Domain.Entities;
using OMS.Infrastructure.Persistence.Data.Repositories;

namespace OMS.Application.Features.Users.Handlers;

public class GetAllUsersQueryHandler : BaseQueryHandler<GetAllUsersQuery, IEnumerable<UserDto>>
{
    // Fields
    private readonly IBaseRepository<User> _userBaseRepository;
    private readonly IMapper _mapper;

    // Constructors
    public GetAllUsersQueryHandler(
        IRepositoryFactory repositoryFactory,
        IMapper mapper)
    {
        _userBaseRepository = repositoryFactory.GetRepository<User>();
        _mapper = mapper;
    }

    //Methods
    protected override async Task<IEnumerable<UserDto>> HandleQuery(GetAllUsersQuery query, CancellationToken cancellationToken)
    {
        try
        {
            // Get all users
            var users = await _userBaseRepository.GetAllAsync(cancellationToken: cancellationToken);

            // Map users to Dto
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }
        catch (Exception e)
        {
            throw;
        }
    }
}