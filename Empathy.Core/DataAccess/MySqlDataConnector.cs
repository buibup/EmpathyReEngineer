using System;
using System.Net.Http;

namespace Empathy.Core.DataAccess
{
    public class MySqlDataConnector : IMySqlDataConnection
    {
        public HttpResponseMessage GetImageLineByUserId(string userId, int width, int height)
        {
            throw new NotImplementedException();
        }
    }
}
