using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TestAdventOfCode2024")]

namespace AoC2024D1P1
{
    internal class Day2 //add Exception Handling
    {
        private readonly PathsService _pathsService;
        private readonly string[] _inputStr;

        public Day2(PathsService service)
        {
            _pathsService = service;
            _inputStr = _pathsService.ReadAllLines(nameof(Paths.InputStrDay2));
        }

        internal void SolutionDay2()
        {
            ParseInput();
        }

        internal void ParseInput()
        {
            List<int> rowsIntValues = new List<int>();
            int safeReportsCount = 0;
            for (int i = 0; i < _inputStr.Length; i++)
            {
                string[] separatedRowsStr = _inputStr[i].Split(' ');

                foreach (string valueStr in separatedRowsStr)
                {
                    int value = int.Parse(valueStr);
                    rowsIntValues.Add(value);                  
                }
 
                if(IsSafe(rowsIntValues))
                {
                    safeReportsCount ++;
                }
                rowsIntValues.Clear();
            }

            Console.WriteLine(safeReportsCount);
        }

        private bool IsSafe(List<int> values)
        {
            bool isAscSorted = true;
            bool isDescSorted = true;

            if (values == null || values.Count < 2)
                return false;
        
            for (int i = 1; i < values.Count; i++)
            {
                int diff = Math.Abs(values[i - 1] - values[i]); //calculate the difference
                
                if(diff < 1 || diff > 3) 
                    return false;

                if (values[i] > values[i - 1]) //check if the list is sorted in ascending order          
                    isAscSorted = false;

                if (values[i] < values[i - 1]) //check if the list is sorted in descending order
                    isDescSorted = false;
            }

            return isAscSorted || isDescSorted;
        }
    }
}
