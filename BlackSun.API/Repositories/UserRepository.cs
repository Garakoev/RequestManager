using AutoMapper;
using BlackSun.Core.Repositories;
using BlackSun.Database.Contexts;
using BlackSun.Database.Models;

namespace BlackSun.API.Repositories;

public class UserRepository : Repository<User>
{
    public UserRepository(DatabaseContext databaseContext, Mapper mapper) : base(databaseContext, mapper)
    {
    }
}