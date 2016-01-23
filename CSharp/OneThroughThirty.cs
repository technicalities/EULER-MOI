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
    {   if (i % 3 == 0 || i % 5 == 0)
        {		sum += i;		}
    }
    Console.WriteLine("Solution 1 is " + sum);
	}
	// O(n) in time, O(1) in space.


  //  2. Find the sum of the even terms in the Fibonacci subsequence below 4m.
  //  sumEvenFibonaccisBelowLimit()
	public static void EulerTwo (int limit)
  {
    int sum = 0;
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
	 // O() in time, O() in space.
   // The actually distinctive C# solution would be LINQing it:
   //     var sum = fibonacci.Where(i => (i % 2 == 0)).Sum(i => (long)i);


	//  3. Get the largest prime factor of 600851475143
	//  maxFactor()
	public static void EulerThree (long target)
	{   List<int> factors = new List<int>();
	    List<int> primes = new List<int>();
			// Key: if no primes smaller than <number> are a proper divisor of it, <number> is prime
	    for (var i = 2; i < Math.Sqrt(target); i++)
	    {
	        if ( !primes.Exists(p => (i % p == 0)) )
	        {
	          if (target % i == 0)
	          {		factors.Add(i);		}
	          primes.Add(i);
	        }
	    }
	    Console.WriteLine("Solution 3 is " + factors.Last() );
	  }
// O() in time, O(log n) in space.


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
// O() in time, O() in space.


  //  5.  Find the smallest positive number evenly divisible by all numbers from 1-20?
  //  getLeastCommonDividend();
  public static void EulerFive (int limit)
  {
      int candidate = 1;
      int? leastDividend = null;
      // Key: if candidate is divisible by <number> then it's divisible by all <number>'s factors.
			// Thus we can omit the first half of factor list:
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
// O() in time, O() in space.


//  6. Find the difference between the sum of the squares of the first 100 natural numbers
//  and the square of the sum. //  powerOfSumMinusSumOfPowers()
public static void EulerSix (int terminus, int power)
{
    int sum = 0;
    double diff, powerSum;
    diff = powerSum = 0.0;
		// Key fact: the sum of a subsequence of the naturals is just: \frac{n(n+1)}{2}
    sum = terminus * (terminus+1) / 2;

    // Sum the powers of each from 1 to terminus:
    for (int i = 1; i <= terminus; i++)
    {    powerSum += Math.Pow(i, power);    }

    diff = Math.Pow(sum, power) - powerSum ;
    Console.WriteLine("Solution 6 is: " + diff);
}
// O() in time, O() in space.


//  7. Find the 10001st prime. getNthPrime(int n)
public static void EulerSeven(int n)
{
   List<int> primes = new List<int>();  // Store primes as we go
   int first = 2;
   primes.Add(first);
   // Only need to test odd numbers: init to 1, iterate +2:
   int candidate = 1;
   bool isPrime;

   while(primes.Count < n)
   {
     candidate += 2;
     isPrime = true; 			// seek disproof
		 // Key: see line 52 above.
     for (int j = 0; primes[j] * primes[j] <= candidate; j++ )
		 {   if (candidate % primes[j] == 0)
			   {   isPrime = false;
             break;
         }
     }
     if (isPrime)
		 {		primes.Add(candidate);		}
   }
   Console.WriteLine("Solution 7 is " + primes.Last());
}
// Time O(n^2), space O(n).


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
