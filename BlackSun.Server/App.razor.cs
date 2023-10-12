using System.Reflection;

namespace BlackSun.Server;

public partial class App
{
    private IEnumerable<Assembly> AdditionalAssemblies { get; set; } = Enumerable.Empty<Assembly>();
}