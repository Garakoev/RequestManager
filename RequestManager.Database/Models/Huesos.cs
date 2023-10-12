using RequestManager.Database.Models.Common;

namespace RequestManager.Database.Models;

public class Huesos : AuditableDatabaseEntity
{
    public string Name { get; set; }
}