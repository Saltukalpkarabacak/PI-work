using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class Program
{
        // PI WORKS TASK SALTUK ALP KARABACAK LANGUAGE C#
        // RESARCH SITES : STACKOWERFLOW AND GİTHUB


    public static void Main()
    {

        Input();
        Result();

    }
    private static void Input()
    {
        var triangleInput = @"1
							 8 4
							 2 6 9
							8 5 9 3";

        var splittedInput = ConvertToStringArray(triangleInput);
        var TwoDimensionalArray = Build2DArray(splittedInput);
        var NonPrimeNumbersArray = ReplacePrimeNumbersToZero(TwoDimensionalArray);
        var MaxSum = TraversingArrayForMaximum(TwoDimensionalArray);

        Console.WriteLine($"The Maximum Sum of Non-Prime Number is :  {MaxSum}");

    }
    private static void Result()
    {
        var triangleInput = Input2();
        var splittedInput = ConvertToStringArray(triangleInput);
        var TwoDimensionalArray = Build2DArray(splittedInput);
        var NonPrimeNumbersArray = ReplacePrimeNumbersToZero(TwoDimensionalArray);
        var MaxSum = TraversingArrayForMaximum(TwoDimensionalArray);

        Console.WriteLine($"The Maximum Sum of Non-Prime Number is :  {MaxSum}");

    }

    private static string Input2()
    {
        const string triangleInput = @"215
							193 124
		  				  117 237 442
                        218 935 347 235
                      320 804 522 417 345
                    229 601 723 835 133 124
                  248 202 277 433 207 263 257
                359 464 504 528 516 716 871 182
              461 441 426 656 863 560 380 171 923
            381 348 573 533 447 632 387 176 975 449
          223 711 445 645 245 543 931 532 937 541 444
        330 131 333 928 377 733 017 778 839 168 197 197
      131 171 522 137 217 224 291 413 528 520 227 229 928
    223 626 034 683 839 053 627 310 713 999 629 817 410 121
  924 622 911 233 325 139 721 218 253 223 107 233 230 124 233";
        return triangleInput;
    }


    private static string[] ConvertToStringArray(string triangleInput) //split format for input  
    {
        return triangleInput.Split('\n');
    }


    private static int[,] Build2DArray(string[] splittedStringArray) // add to 2d array input format
    {

        var twoDimensionalArray = new int[splittedStringArray.Length, splittedStringArray.Length + 1];
        var rowIndex = 0;
        foreach (var row in splittedStringArray)
        {
            var integerArray = row.ConvertStringToIntegerArray();
            var columnIndex = 0;
            foreach (var integer in integerArray)
            {
                twoDimensionalArray[rowIndex, columnIndex] = integer;
                columnIndex++;
            }
            rowIndex++;
        }
        return twoDimensionalArray;
    }


    private static int[] ConvertStringToIntegerArray(this string rows)
    {
        return
            Regex
                .Matches(rows, "[0-9]+")
                .Cast<Match>()
                .Select(m => int.Parse(m.Value)).ToArray();
    }

    private static int[,] ReplacePrimeNumbersToZero(int[,] twoDimensionalArray)
    {
        var length = twoDimensionalArray.GetLength(0);
        for (var i = 0; i < length; i++)
        {
            for (var j = 0; j < length; j++)
            {
                if (twoDimensionalArray[i, j] == 0) continue;
                if (IsPrime(twoDimensionalArray[i, j]))
                    twoDimensionalArray[i, j] = 0;
            }
        }
        return twoDimensionalArray;
    }

    private static int TraversingArrayForMaximum(int[,] twoDimensionalArray)
    {
        var data = twoDimensionalArray;
        var length = twoDimensionalArray.GetLength(0);

        for (var i = length - 2; i >= 0; i--)
        {
            for (var j = 0; j < length; j++)
            {
                var c = data[i, j];
                var a = data[i + 1, j];
                var b = data[i + 1, j + 1];
                if ((!IsPrime(c) && !IsPrime(a)) || (!IsPrime(c) && !IsPrime(b)))
                    twoDimensionalArray[i, j] = c + Math.Max(a, b);
            }
        }
        return twoDimensionalArray[0, 0];
    }

    public static bool IsPrime(int number)
    {
        if (number == 1) return false;
        if (number == 2) return true;

        var limit = Math.Ceiling(Math.Sqrt(number)); //hoisting the loop limit

        for (int i = 2; i <= limit; ++i)
            if (number % i == 0)
                return false;
        return true;
    }



}