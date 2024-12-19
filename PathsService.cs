using Microsoft.Extensions.Options;

namespace AoC2024D1P1
{
    internal class PathsService
    {
        private readonly Paths _paths;

        public PathsService(IOptions<Paths> pathsOptions)
        {
            _paths = pathsOptions.Value;
        }

        // Generic method to read all lines from a file based on a property name
        public string[] ReadAllLines(string pathProperty)
        {
            string fullPath = GetPath(pathProperty);

            if (string.IsNullOrWhiteSpace(fullPath))
            {
                Console.WriteLine($"The fullPath '{pathProperty}' is invalid (null or empty).");
                return Array.Empty<string>(); // Return empty array if fullPath is invalid
            }

            try
            {
                if(File.Exists(fullPath)) 
                {
                    return File.ReadAllLines(fullPath);
                }
                else
                    return Array.Empty<string>();
            }
            catch (FileNotFoundException fnfEx)
            {
                Console.WriteLine($"The file at fullPath '{fullPath}' was not found.", fnfEx.StackTrace, fnfEx.Message);
                return Array.Empty<string>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred while reading the file '{fullPath}'.");
                Console.WriteLine($"Exception Message: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                return Array.Empty<string>();
            }
        }

        // Retrieve the fullPath dynamically
        private string GetPath(string pathProperty)
        {
            string? relativeOrAbsolutePath = pathProperty switch
            {
                nameof(Paths.InputStrDay1) => _paths.InputStrDay1,
                nameof(Paths.InputStrDay2) => _paths.InputStrDay2,
                _ => throw new ArgumentException($"Invalid path property: {pathProperty}")
            };
            if(relativeOrAbsolutePath == null) throw new ArgumentNullException(nameof(relativeOrAbsolutePath));

            string fullPath = Path.GetFullPath(relativeOrAbsolutePath, Directory.GetCurrentDirectory());

            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException($"The file '{fullPath}' does not exist.");
            }

            return fullPath;
        }
    }
}