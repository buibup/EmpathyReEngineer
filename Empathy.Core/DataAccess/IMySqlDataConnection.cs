using System.Net.Http;

namespace Empathy.Core.DataAccess
{
    public interface IMySqlDataConnection
    {
        HttpResponseMessage GetImageLineByUserId(string userId, int width, int height);
    }
}
