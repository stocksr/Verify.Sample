using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace VerifyExample;

public static class ModuleInitializer
{
    [ModuleInitializer]
    public static void Initializer()
    {
        VerifierSettings.AddExtraSettings(js => { js.TypeNameHandling = TypeNameHandling.Auto; });
    }
}

public class Tests
{
    [Test]
    public async Task Test1()
    {
        var query = new Query
        {
            Filters = new Filter[]
            {
                new DateRangeFilter { StartDate = new DateOnly(2022, 08, 12), EndDate = new DateOnly(2022, 08, 13) },
                new IsCompleteFilter(),
                new IsSpamFilter()
            }
        };

        await Verify(query);
    }
}

public class Query
{
    public Filter[] Filters { get; set; } = Array.Empty<Filter>();
}

public abstract class Filter
{
}

public class DateRangeFilter : Filter
{
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}

public class IsCompleteFilter : Filter
{
    // no properties needed 
}

public class IsSpamFilter : Filter
{
    // no properties needed 
}