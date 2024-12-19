namespace AoC2024D1P1
{
    internal class Day1 //ADD EXCEPTION HANDLING
    {
        private readonly PathsService _pathsService;
        private readonly string[] _inputStr;
        private int[] leftColumn;
        private int[] rightColumn;

        public Day1(PathsService service)
        {
            _pathsService = service;
            _inputStr = _pathsService.ReadAllLines(nameof(Paths.InputStrDay1)); //parses by \n
            leftColumn = new int[_inputStr.Length];
            rightColumn = new int[_inputStr.Length];
        }

        internal void HandleFlow()
        {
            ParseInput();
            int result = CalculateDistance();
            Console.WriteLine(result);
            int similarityScoreResult = CalculateSimilarityScore();
            Console.WriteLine(similarityScoreResult);
        }

        private void ParseInput()
        {
            for (int i = 0; i < _inputStr.Length; i++)
            {
                string[] separatedValuesStr = _inputStr[i].Split(new[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                leftColumn[i] = int.Parse(separatedValuesStr[0]);
                rightColumn[i] = int.Parse(separatedValuesStr[1]);
            }
        }

        private int CalculateDistance()
        {
            int distance = 0;

            Array.Sort(leftColumn);
            Array.Sort(rightColumn);

            for(int i = 0; i < leftColumn.Length; i++)
            {
               distance += Math.Abs(leftColumn[i] - rightColumn[i]);
            }

            return distance;
        }

        private int CalculateSimilarityScore()
        {
            int similarityScore = 0;

            for (int i = 0; i < leftColumn.Length; i++)
            {
                for (int j = 0; j < rightColumn.Length; j++)
                {
                    if (leftColumn[i] == rightColumn[j])
                    {
                        similarityScore += leftColumn[i];
                    }
                }
            }
            return similarityScore;
        }
    }
}
