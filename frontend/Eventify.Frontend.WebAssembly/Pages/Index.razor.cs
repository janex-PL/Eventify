using Eventify.Frontend.Application;

namespace Eventify.Frontend.WebAssembly.Pages
{
    public partial class Index
    {
        private IEnumerable<EventDto> _events = new List<EventDto>();

        private bool[] IsImageLoaded = new bool[12];
        
        protected void NavigateToEventDetails(int id)
        {
            Navigation.NavigateTo($"/event/{id}");
        }

        protected override void OnInitialized()
        {
            _events = EventService.Get();
        }
    }
}