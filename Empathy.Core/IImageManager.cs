using System.Net.Http;

namespace Empathy.Core
{
    public interface IImageManager
    {
        HttpResponseMessage GetImageLineByUserId(string userId, int width, int height);
        HttpResponseMessage GetImageTrakCareByHn(string hn, int width, int height);
        HttpResponseMessage GetImagePostgresByHn(string hn, int width, int height);
    }
}
