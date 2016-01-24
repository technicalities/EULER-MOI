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


//  8. Find the largest product of n=13 adjacent numbers in {{ProblemData.SERIES_EIGHT}}
//  Solution is a sliding product: Find 1st n-product, multiply by next char and divide by last.
//  This takes much more code because of zeroes breaking the chain, but is much cooler.
public static void EulerEight(String series, int n)
{
	 long product = getProductFromString(series.Substring(0, n));
	 long max = product;	//  max possible is 9^13 > Int32.Max.

   for (int j = n; j < series.Length; j++)
   {
	 	  int next = (series[j] - '0');
		  int previous = (series[j-n] - '0');
			// If you come to a 0, jump it and get a fresh product
			if (next == 0 && j < (series.Length - n) )
			{
					j += n;
					do
					{ // Keep trying until you hit a nonzero stretch of length n:
						product = getProductFromString(series.Substring(j-(n-1), n));
						if (product == 0)	 {
							j++;
						}
					}
					while (product == 0 && j < (series.Length - n));
					continue;
			}
			else
			{
				previous = (previous == 0) ? 1 : previous; // have to prevent DIV/0s
				product = product * next / previous;			// all the rest of the machinery is for this nice line.
			}
			if (product > max)
				max = product;
   }
   Console.WriteLine("Solution 8 is " + max + "\n\n");
}
// Time O(n^2), space O(n) by string length; Time O(n^2), space O(n) by multiplicand width.
private static long getProductFromString(string subseries)
{
		int product = 1;
		for (int i = 0; i < subseries.Length; i++)
		{ 	product *= (subseries[i] - '0');		}		// char to int

		return product;
}

}



public static class ProblemData
{
		public const String SERIES_EIGHT =
			"7316717653133624919225119674426574742355349194934" +
			"96983520312774506326239578318016984801869478851843" +
			"85861560789112949495459501737958331952853208805511" +
			"12540698747158523863050715693290963295227443043557" +
			"66896648950445244523161731856403098711121722383113" +
			"62229893423380308135336276614282806444486645238749" +
			"30358907296290491560440772390713810515859307960866" +
			"70172427121883998797908792274921901699720888093776" +
			"65727333001053367881220235421809751254540594752243" +
			"52584907711670556013604839586446706324415722155397" +
			"53697817977846174064955149290862569321978468622482" +
			"83972241375657056057490261407972968652414535100474" +
			"82166370484403199890008895243450658541227588666881" +
			"16427171479924442928230863465674813919123162824586" +
			"17866458359124566529476545682848912883142607690042" +
			"24219022671055626321111109370544217506941658960408" +
			"07198403850962455444362981230987879927244284909188" +
			"84580156166097919133875499200524063689912560717606" +
			"05886116467109405077541002256983155200055935729725" +
			"71636269561882670428252483600823257530420752963450";
}

}
