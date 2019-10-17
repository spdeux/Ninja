namespace Ninja.Mocking
{
    public interface IFileDownloader
    {
        void DownloadFile(string url, string path);
    }
}