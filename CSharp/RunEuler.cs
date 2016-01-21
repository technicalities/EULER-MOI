using System;
using System.Linq;
using System.Collections.Generic;
using pe = ProjectEuler.OneThroughThirty;

public static class RunEuler
{
    static public void Main(string[] args)
    {
      pe.EulerOne(1000);    //  sumThreesAndFivesBelowLimit()
      pe.EulerTwo(4000000); //  sumEvenFibonaccisBelowLimit()
      // 70 seconds on a netbook
      pe.EulerThree(600851475143); //  maxPrimeFactor()
      pe.EulerFour(3);      //  findMaxPalindromeForN()
      pe.EulerFive(20);     //  getLeastCommonDividend();
      pe.EulerSix(100, 2);  //  powerOfSumMinusSumOfPowers()
    }
}
