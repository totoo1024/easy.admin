using Furion;
using System.Reflection;

namespace Easy.Admin.Web.Entry;

public class SingleFilePublish : ISingleFilePublish
{
    public Assembly[] IncludeAssemblies()
    {
        return Array.Empty<Assembly>();
    }

    public string[] IncludeAssemblyNames()
    {
        return new[]
        {
            "Easy.Admin.Application",
            "Easy.Admin.Core",
            "Easy.Admin.Web.Core"
        };
    }
}