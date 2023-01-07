using Maze.Models;
using Maze.Solvers;

sealed class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Please enter file location: ");
        var fileLocation = Console.ReadLine();

        if (!File.Exists(fileLocation))
        {
            Console.WriteLine("File does not exist");
        }
        else
        {
            var ext = Path.GetExtension(fileLocation);
            if (ext != ".txt")
            {
                Console.WriteLine("Only .txt files are supported");
                return;
            }

            Console.WriteLine("Please enter number of tries: ");
            var triesInput = Console.ReadLine();
            int tries = int.Parse(triesInput);

            try
            {

                string[] lines = await FileHandler.LoadLinesAsync(fileLocation);
                var maze = new Maze.Models.Maze(lines);
                if (maze != null)
                {
                    IMazeSolver mazeSolver = new RecursiveSolver(maze, tries);
                    string[] result = mazeSolver.Solve(lines);
                    if (result.Length <= 0)
                    {
                        throw new Exception($"Maze could not be solved within {tries} tries");
                    }
                    else
                    {
                        var filename = Path.GetFileNameWithoutExtension(fileLocation);
                        filename += "-result.txt";
                        var resultFileLocation = Path.Combine(Path.GetDirectoryName(fileLocation), filename);
                        await FileHandler.SaveLinesAsync(result, resultFileLocation);

                        Console.WriteLine($"Maze solved! Result file saved to {resultFileLocation}");
                    }

                }
                else
                {
                    throw new Exception("Something went wrong! Maze build failed");
                }

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}