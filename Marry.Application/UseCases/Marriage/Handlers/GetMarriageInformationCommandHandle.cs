using Marry.Application.Absreactions;
using Marry.Application.UseCases.Marriage.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Marry.Application.UseCases.Marriage.Handlers
{
    public class GetMarriageInformationCommandHandle : IRequestHandler<GetMarriageInformationCommand, List<Domain.Entities.Marriage>>
    {

        private readonly IApplicationDbContext _appplicationDbContext;

        public GetMarriageInformationCommandHandle(IApplicationDbContext appplicationDbContext)
        {
            _appplicationDbContext = appplicationDbContext;
        }
        public async Task<List<Domain.Entities.Marriage>> Handle(GetMarriageInformationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _appplicationDbContext.Marriages.ToListAsync();
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}

/*public async Task<List<WeatherForecast>> SetAsync()
{
var value = Enumerable.Range(1, 5).Select(index => new WeatherForecast
{
    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
    TemperatureC = Random.Shared.Next(-20, 55),
    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
}).ToArray();

var serialize = JsonSerializer.Serialize(value);

await _distributedCache.SetStringAsync("Key", serialize, new DistributedCacheEntryOptions()
{
    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60)
});

List<WeatherForecast> result = JsonSerializer.Deserialize<List<WeatherForecast>>(serialize).ToList();

return result;
}*/