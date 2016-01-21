using System;
using System.Linq;
using System.Collections.Generic;

namespace ProjectEuler
{

static class OneThroughThirty
{
    //  1. Find the sum of all multiples of 3 or 5 below 1000.
    //  sumThreesAndFivesBelowLimit()
		public static void EulerOne (int limit)
		{
      int sum = 0;
      for (var i = 1; i < limit; i++)
      {
          if (i % 3 == 0 || i % 5 == 0)
          {
              sum += i;
          }
      }
      Console.WriteLine("Solution 1 is " + sum);
		}

    //  2. Find the sum of the even terms in the Fibonacci subsequence below 4m.
    //  sumEvenFibonaccisBelowLimit()
		public static void EulerTwo (int limit)
    {
      int sum = 0; // skip the first evennum as a special case
      int g,h;
      g = 1;
      h = 2;

      for (var i = 3; i < limit; i = g+h)
      {   if (i % 2 == 0)
		        sum += i;

          g = h;
          h = i;
      }
      Console.WriteLine("Solution 2 is " + sum);
	   }
     // The actually distinctive C# solution would be LINQing it:
     //     List<int> fibonacci = new List<int>(); ...
     //     var sum = fibonacci.Where(i => (i % 2 == 0)).Sum(i => (long)i);


    //  3. Get the largest prime factor of 600851475143
    //  maxFactor()
    public static void EulerThree (long target)
    {   List<int> factors = new List<int>();
        List<int> primes = new List<int>();
        for (var i = 2; i < Math.Sqrt(target); i++)
        {
            if ( !primes.Exists(p => (i % p == 0)) )
            {
              if (target % i == 0)
              {
                factors.Add(i);
              }
                primes.Add(i);
            }
        }
        Console.WriteLine("Solution 3 is " + factors.Last() );
      }


  //  4.  Find the largest palindrome made from the product of two 3-digit numbers.
  //  findMaxPalindromeForN ()
  public static void EulerFour (int digits)
  {   int maxMultiplicand = Int32.Parse(String.Concat(Enumerable.Repeat("9", digits)));
      var product = 0;
      var maxPalindrome = 0;

      for (var i = maxMultiplicand; i > 1; i--)
      {
        for (var j = maxMultiplicand; j > 1; j--)
        {
          product = i * j;
          if (isPalindrome(product) && product > maxPalindrome)
          {
            maxPalindrome = product;
            break;
          }
        }
      }
      Console.WriteLine("Solution 4 is " + maxPalindrome );
  }
  private static bool isPalindrome (int product)
  {
    var productTest = product.ToString();
    var prodLength = productTest.Length;

    // we only need to iterate through half the string:
    var j = prodLength-1;
    for (var i = 0; i < prodLength/2; i++)
    {
      if (productTest[i] != productTest[j])
        return false;
      j--;
    }
    return true;
  }


  //  5.  What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
  //  getLeastCommonDividend(10); // => 2520
  public static void EulerFive (int limit)
  {
      int candidate = 1;
      int? leastDividend = null;
      // If divisible by 20 then divisible by 2,4,5,10. If 18 then also 3,6,9. etc...
      int initial = (limit / 2);

      while (! leastDividend.HasValue )
      {
          for (int i=initial; i <= limit; i++)
          {
            if ( candidate % i != 0 )
            {
               candidate++;
               i = initial;
            }
          }
        leastDividend = candidate;
     }

     Console.WriteLine("Solution 5 is : " + leastDividend);
  }


//  6. Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
//  powerOfSumMinusSumOfPowers()
public static void EulerSix (int terminus, int power)
{
    int sum = 0;
    double diff, powerSum;
    diff = powerSum = 0.0;
    // Sum of a finite arithmetic sequence is just: \frac{n(n+1)}{2}
    sum = terminus * (terminus+1) / 2;

    // Sum of the powers of each, 1 to terminus:
    for (int i = 1; i <= terminus; i++)
    {    powerSum += Math.Pow(i, power);    }

    diff = Math.Pow(sum, power) - powerSum ;
    Console.WriteLine("Solution 6 is: " + diff);
}


//
// //  7.
//   public static void EulerSeven (int target)
//   {   long source = (long)target;
//       int sum = 0;
//       for (var i = 2; i < Math.Sqrt(source); i++)
//       {
//
//       }
//       getOut(sum);
//   }
//
// //  8.
//   public static void EulerEight (int target)
//   {   long source = (long)target;
//       int sum = 0;
//       for (var i = 2; i < Math.Sqrt(source); i++)
//       {
//
//       }
//       getOut(sum);
//   }
// //  9.
//
//   public static void EulerNine (int target)
//   {   long source = (long)target;
//       int sum = 0;
//       for (var i = 2; i < Math.Sqrt(source); i++)
//       {
//
//       }
//       getOut(sum);
//   }
// //  10.
//
//   public static void EulerTen (int target)
//   {   long source = (long)target;
//       int sum = 0;
//       for (var i = 2; i < Math.Sqrt(source); i++)
//       {
//
//       }
//       getOut(sum);
//   }
}

}
