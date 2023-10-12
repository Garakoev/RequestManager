﻿using AutoMapper;

namespace BlackSun.API.Common;

public interface IMapFrom<T>
{
    void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
}