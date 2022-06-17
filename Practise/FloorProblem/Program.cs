using System.Runtime.CompilerServices;

namespace FloorProblem
{
    public class Program
    {
        /* Assumptions made:
         1) Considering two board sizes 2x1 and 3x1. In case no of the pattern matches, by default there will always be two possible layouts
         * i.e. 2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2
                3,2,2,2,2,2,2,2,2,2,2,2,2,2,3       
            and oppossible of it.
         2) Evaluation of first two floors should be sufficient since first floor value 
            can be replicated on all remaining odd floors and 2nd floor to all even floors.  
         */     
        private const int DEFAULT_COMBINATION = 2; 
        const int MAX_LENGTH = 9;
        
        internal class BoardSizeTracker
        {
            public string LengthPattern { get; set; }
            public List<int> TotalLength { get; set; }
        }
        
        public static void Main(string[] args)
        {
            if (MAX_LENGTH <= 4)
            {
                Console.WriteLine($"Considering board size , possible combnations are ZERO..");
                return;
            }

            var maxBoards = (int)Math.Floor((double)MAX_LENGTH / 2); //9
            var maxCombinations = (int)Math.Pow(maxBoards, 2);
            var combinations = new List<BoardSizeTracker>();
            var ignoreZeros = new List<int>() { 0 };
            
            for (var bits = 0; bits < maxCombinations; bits++)
            {
                var wall = new Wall { Bits = bits };
                var boardCombo = wall.GetBoards(MAX_LENGTH);
                if (boardCombo.totalLength == MAX_LENGTH)
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

            var acceptableCombinationCount = 0;
            for (var i=0;i<combinations.Count;i++)
            {
                var basePattern = combinations[i];
                for (var j = 0; j < combinations.Count; j++)
                {
                    var output = basePattern.TotalLength.Intersect(combinations[j].TotalLength);
                    if(output.Count() >1)
                        continue;
                    if (output.Count() == 1 && output.First() == 9)
                    {
                        acceptableCombinationCount++;
                        Console.WriteLine($"Layout Option : {acceptableCombinationCount}");
                        Console.WriteLine($"Odd Floor Board Layout : {basePattern.LengthPattern}");
                        Console.WriteLine($"Event Floor Board Layout : {combinations[j].LengthPattern}");
                        Console.WriteLine($"************************************************************");
                    }
                }
            }
            acceptableCombinationCount =
                acceptableCombinationCount == 0 ? DEFAULT_COMBINATION : acceptableCombinationCount;
            Console.WriteLine($"Total acceptable combination count : {acceptableCombinationCount}..");
        }
        
        public class Wall
        {    
            public int Bits { get; set; }
            
            public (IEnumerable<int> boards, int totalLength,IEnumerable<int> boardLengthTracker) GetBoards(int maxLength)
            {
                var boards = new int[maxLength];
                var totalBoardLengthTracker = new int[maxLength];
                var totalLength = 0;
                var bits = Bits;
                int numBoards = 0;
                for(int i = 0; i <= maxLength;)
                {
                    var board = ((bits & 1) == 1) ? 3 : 2;
                    if (totalLength + board < maxLength)
                    {
                        boards[i] = board;
                        totalLength += board;
                        totalBoardLengthTracker[i] = totalLength; 
                        i++;
                        bits >>= 1; 
                    }
                    else if (totalLength + board > maxLength)
                    {
                        return default;
                    }
                    else
                    {
                        boards[i] = board;
                        totalLength += board;
                        totalBoardLengthTracker[i] = totalLength;
                        numBoards = i;
                        break;
                    }
                }

                return (boards.Take(numBoards + 1), totalLength,totalBoardLengthTracker);
            }
        }
    }
}

 