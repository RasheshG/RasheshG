namespace FloorProblem.Implementation;

internal class LayoutCombinationEvaluator
{
    internal class BoardSizeTracker
    {
        public string LengthPattern { get; set; }
        public List<int> TotalLength { get; set; }
    }
    
    
    private const int DEFAULT_COMBINATION = 2;
    private const int STARTS_BIT_VALUE = 1;
    private const int SMALL_BOARD_SIZE = 2;
    internal int DoWork(int maxLength)
    {
        if (maxLength <= 4)
        {
            Console.WriteLine($"Considering board size , possible combnations are ZERO..");
            return 0;
        }
        
        var maxBoards = (int)Math.Floor((double)maxLength / SMALL_BOARD_SIZE); 
        var maxCombinations = (int)Math.Pow(maxBoards, SMALL_BOARD_SIZE);
        var combinations = new List<BoardSizeTracker>();
       
        var ignoreZeros = new List<int>() { 0 };

        for (var bits = STARTS_BIT_VALUE; bits <= maxCombinations; bits++)
        {
            var wall = new Wall { Bits = bits };
            var boardCombo = wall.GetBoards(maxLength);
            if (boardCombo.totalLength == maxLength)
            {
                var instance = new BoardSizeTracker()
                {
                    LengthPattern = string.Join(",", boardCombo.boards),
                    TotalLength = boardCombo.boardLengthTracker.ToList().Except(ignoreZeros).ToList()
                };
                Console.WriteLine($"Possible Odd floor layout pattern : {instance.LengthPattern}.");
                combinations.Add(instance);
            }
        }
        return DeriveLayoutCombinations(combinations, maxLength);
    }

    private int DeriveLayoutCombinations(List<BoardSizeTracker> combinations, int maxLength)
    {
        var result = new List<string>();
        var acceptableCombinationCount = 0;
        for (var i = 0; i < combinations.Count; i++)
        {
            var basePattern = combinations[i];
            for (var j = 0; j < combinations.Count; j++)
            {
                var output = basePattern.TotalLength.Intersect(combinations[j].TotalLength);
                if (output.Count() > 1)
                    continue;
                if (output.Count() == 1 && output.First() == maxLength)
                {
                    acceptableCombinationCount++;
                    result.Add(basePattern.LengthPattern + "=>" + combinations[j].LengthPattern);
                    Console.WriteLine($"Layout Option : {acceptableCombinationCount}");
                    Console.WriteLine($"Odd Floor Board Layout : {basePattern.LengthPattern}");
                    Console.WriteLine($"Event Floor Board Layout : {combinations[j].LengthPattern}");
                    Console.WriteLine($"************************************************************");
                }
            }
        }
        acceptableCombinationCount =
            acceptableCombinationCount == 0 ? DEFAULT_COMBINATION : result.Distinct().Count();
        
        return acceptableCombinationCount;
    }
}