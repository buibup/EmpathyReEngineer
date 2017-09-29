using System;
using System.Net.Http;

namespace Empathy.Core
{
    public class ImageManager : IImageManager
    {
        public HttpResponseMessage GetImageLineByUserId(string userId, int width, int height)
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage GetImagePostgresByHn(string hn, int width, int height)
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage GetImageTrakCareByHn(string hn, int width, int height)
        {
            throw new NotImplementedException();
        }
    }
}
