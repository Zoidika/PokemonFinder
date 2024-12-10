using System.Text.Json;

namespace PokemonFinder.Services
{
    public class SessionService
    {
        private readonly ISession _session;

        public SessionService(IHttpContextAccessor context)
        {
            _session = context.HttpContext.Session;
        }

        public async Task SaveItem<T>(T item, string key)
        {
            await _session.LoadAsync();
            _session.SetString(key, JsonSerializer.Serialize(item));
            await _session.CommitAsync();
        }

        public async Task<T> GetItem<T>(string key)
        {
            await _session.LoadAsync();
            var value = _session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }

        public void ClearSessionData()
        {
            _session.Clear();
        }

        public async Task ClearItem(string key)
        {
            await _session.LoadAsync();
            _session.Remove(key);
            await _session.CommitAsync();
        }

    }
}
