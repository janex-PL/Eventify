namespace Eventify.Frontend.Application;

public interface IEventService
{
    public IEnumerable<EventDto> Get(int page = 0, int size = 12);
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
}

public interface IEventRepository
{
    IEnumerable<EventDto> Get(int page = 0, int size = 10);
}