using System.Threading.Tasks;

namespace RemoteConfingCourse
{
    public interface IConfigContainer
    {
        public Task<string> GetString(string key, string defaultValue = "null", int numberOfTries = 5);
        public Task<int> GetInt(string key, int defaultValue = 0, int numberOfTries = 5);
        public Task<float> GetFloat(string key, float defaultValue = 0, int numberOfTries = 5);
    }
}