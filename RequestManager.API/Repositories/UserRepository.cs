﻿using AutoMapper;
using RequestManager.Core.Repositories;
using RequestManager.Database.Contexts;
using RequestManager.Database.Models;

namespace RequestManager.API.Repositories;

public class UserRepository : Repository<User>
{
    public UserRepository(DatabaseContext databaseContext, Mapper mapper) : base(databaseContext, mapper)
    {
    }
}