namespace Eventify.Frontend.Application;

public interface IEventService
{
    public IEnumerable<EventDto> Get(int page = 0, int size = 12);
    public EventDto? GetById(int id);
}

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;

    public EventService(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public IEnumerable<EventDto> Get(int page = 0, int size = 12)
    {
        return _eventRepository.Get(page,size);
    }

    public EventDto? GetById(int id)
    {
        return _eventRepository.GetById(id);
    }
}

public interface IEventRepository
{
    IEnumerable<EventDto> Get(int page = 0, int size = 10);
    EventDto? GetById(int id);
}