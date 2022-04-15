using System.Text;

namespace Server.Logger
{
    public class Logger : ILogger
    {

        private string _pathToFile = "";
        public async void Log(LogLevel logLevel, string methodName, string message)
        {
            string line = $"{DateTime.Now}\t{logLevel}\t{methodName}\t{message}";
            await WriteLogLine(line);
        }

        public Logger()
        {
            InitializeLogger();
        }

        private void InitializeLogger()
        {
            string logDate = DateTime.Today.ToString("yyyy-MM-dd");
            string path = $@"{Directory.GetCurrentDirectory()}\log";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string pathToFile = $@"{path}\{logDate}";
            if (!File.Exists(pathToFile))
            {
                File.Create(pathToFile);
            }
            _pathToFile = pathToFile;
        }

        private async Task<bool> WriteLogLine(string line)
        {
            Byte[] bytes = Encoding.ASCII.GetBytes(line);
            using(FileStream fs = File.OpenRead(_pathToFile))
            {
                try
                {
                    await fs.WriteAsync(bytes);
                    return true;
                }
                catch (Exception ex)
                {   
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }


    }
}
