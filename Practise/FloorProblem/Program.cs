using System.Runtime.CompilerServices;
using FloorProblem.Implementation;

namespace FloorProblem
{
    public class Program
    {
        /*
             Assumptions made:
             1) Evaluation of first two floors should be sufficient since first floor value 
                can be replicated into all remaining odd floors and same logic is applicable in case of 2nd & even floors.  
             2) Considering two board sizes 2x1 and 3x1. In case no of the pattern matches, by default there will always be two possible layouts
             * i.e. 2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2
                    3,2,2,2,2,2,2,2,2,2,2,2,2,2,3       
                and oppossible of it.
             3) considering board sizes (2x1 and 3x1) , floor size must be minimum 5 otherwise pattern count will be 0.
         */

        public static void Main(string[] args)
        {
            Console.WriteLine("Combination evaluation started..");
            var evaluator = new LayoutCombinationEvaluator();
            var result = evaluator.DoWork(9);
            Console.WriteLine($"Total acceptable combination count : {result}..");
            Console.WriteLine("Combination evaluation completed..");
        }
    }
}

 