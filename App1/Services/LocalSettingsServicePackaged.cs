using System.Threading.Tasks;

using App1.Contracts.Services;
using App1.Core.Helpers;

using Windows.Storage;

namespace App1.Services;

public class LocalSettingsServicePackaged : ILocalSettingsService
{
    public async Task<T> ReadSettingAsync<T>(string key)
    {
        if (ApplicationData.Current.LocalSettings.Values.TryGetValue(key, out var obj))
        {
            return await Json.ToObjectAsync<T>((string)obj);
        }

        return default;
    }

    public async Task SaveSettingAsync<T>(string key, T value)
    {
        ApplicationData.Current.LocalSettings.Values[key] = await Json.StringifyAsync(value);
    }
}
