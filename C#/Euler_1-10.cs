using System;
using System.Linq;
using System.Collections.Generic;

//  Each problem is solved by a method which is generalised over the key input.

public static class OneThroughTen
{
    static public void Main(string[] args)
    {
      EulerOne(1000);
      EulerTwo(4000000);
      EulerThree(600851475143); // 70s on a netbook
      EulerFour(3);
    }

    static int exercise = 0; // Just a task index for the output
    static void getOut (int output)
    {
      exercise++;
      Console.WriteLine("Solution " + exercise + " is: " + output);
    }

//  1. Find the sum of all multiples of 3 or 5 below 1000.
		public static void EulerOne (int theLimit)
		{
      int sum = 0;
      for (var i = 1; i < theLimit; i++)
      {
          if (i % 3 == 0 || i % 5 == 0)
          {
              sum += i;
          }
      }
      getOut(sum);
		}

//  2. Find the sum of the even terms in the Fibonacci subsequence below 4m.
		public static void EulerTwo (int theLimit)
    {
      int sum = 0; // skip the first evennum as a special case
      int limit = theLimit;
      int g,h;
      g = 1;
      h = 2;

      for (var i = 3; i < limit; i = g+h)
      {   if (i % 2 == 0)
		        sum += i;

          g = h;
          h = i;
      }
      getOut(sum);
	   }
     // The actually distinctive C# solution would be LINQing it:
     //     List<int> fibonacci = new List<int>(); ...
     //     var sum = fibonacci.Where(i => (i % 2 == 0)).Sum(i => (long)i);


//  3. Get the largest prime factor of 600851475143
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
        getOut(factors.Last());
      }


//  4.  Find the largest palindrome made from the product of two 3-digit numbers.
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
      getOut(maxPalindrome);
  }
  private static bool isPalindrome (int product)
  {
    var productTest = product.ToString();
    var prodLength = productTest.Length;

    // Technically we only need to iterate through half the string:
    var j = prodLength-1;
    for (var i = 0; i < prodLength/2; i++)
    {
      if (productTest[i] != productTest[j])
        return false;
      j--;
    }
    return true;
  }


//  5.
  public static void EulerFive (int target)
  {   long source = (long)target;
      int sum = 0;
      for (var i = 2; i < Math.Sqrt(source); i++)
      {

      }
      getOut(sum);
  }

//  6.

  public static void EulerSix (int target)
  {   long source = (long)target;
      int sum = 0;
      for (var i = 2; i < Math.Sqrt(source); i++)
      {

      }
      getOut(sum);
  }
//  7.

  public static void EulerSeven (int target)
  {   long source = (long)target;
      int sum = 0;
      for (var i = 2; i < Math.Sqrt(source); i++)
      {

      }
      getOut(sum);
  }
//  8.

  public static void EulerEight (int target)
  {   long source = (long)target;
      int sum = 0;
      for (var i = 2; i < Math.Sqrt(source); i++)
      {

      }
      getOut(sum);
  }
//  9.

  public static void EulerNine (int target)
  {   long source = (long)target;
      int sum = 0;
      for (var i = 2; i < Math.Sqrt(source); i++)
      {

      }
      getOut(sum);
  }
//  10.

  public static void EulerTen (int target)
  {   long source = (long)target;
      int sum = 0;
      for (var i = 2; i < Math.Sqrt(source); i++)
      {

      }
      getOut(sum);
  }

}
