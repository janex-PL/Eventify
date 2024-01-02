using Eventify.Frontend.Application;

namespace Eventify.Frontend.Infrastructure;

public class FakeEventRepository : IEventRepository
{
    public IEnumerable<EventDto> Get(int page = 0, int size = 12)
    {
        return Enumerable.Range(page*size,size).Select(x => new EventDto(x,$"Event {x}", DateTime.Now.AddDays(x), $"https://picsum.photos/seed/{x+1}/1920/1080", 100, new LocationDto("Bar Miś",$"ul. Zwykła {x}","","50-320","Wroclaw","Polska",0.0,0.0)));
    }

    public EventDto? GetById(int id)
    {
        return id % 2 == 0 ? new EventDto(id,$"Event {id}", DateTime.Now.AddDays(id), $"https://picsum.photos/seed/{id+1}/1920/1080", 100, new LocationDto("Bar Miś",$"ul. Zwykła {id}","","50-320","Wroclaw","Polska",0.0,0.0)) : null;
    }
}
