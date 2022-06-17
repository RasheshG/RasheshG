namespace FloorProblem.Implementation;

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