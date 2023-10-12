using BlackSun.Database.Models.Common;

namespace BlackSun.Database.Models;

public class Huesos : AuditableDatabaseEntity
{
    public string Name { get; set; }
}
