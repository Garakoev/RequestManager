using BlackSun.Database.Models.Common.Interfaces;

namespace BlackSun.Database.Models.Common;

public abstract class DatabaseEntity : IDatabaseEntity
{
    public long Id { get; set; }
}