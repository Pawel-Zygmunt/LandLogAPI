namespace LandLogAPI.Services
{
    public interface IParcelService
    {
        public Task GetParcelByLatLng(double lat, double lng);
    }

    public class ParcelService : IParcelService
    {
        //jesli user zalogowany to sprawdzic w bazie czy ma taką działke juz zapisaną, jeśli tak to zwrócic mu ją ze zdjęciami, notatkami itd

        //jeśli niezalogowany to pobrać działke z gugik 

        private readonly IParcelService _parcelService;
        private readonly IUserContextService _userContextService;
        public ParcelService(IParcelService parcelService, IUserContextService userContextService)
        {
            _parcelService = parcelService;
            _userContextService = userContextService;
        }

        public async Task GetParcelByLatLng(double lat, double lng)
        {

        }

        public async Task AddParcelToProject()
        {

        }

        public async Task RemoveParcelFromProject()
        {

        }

        public async Task ChangeProjectForParcel()
        {

        }

        private double CalculateParcelArea()
        {
            throw new NotImplementedException();
        }
    }
}
