using System;
using System.Linq;
using System.Collections.Generic;
using pe = ProjectEuler.OneThroughThirty;
using data = ProjectEuler.ProblemData;

public static class RunEuler
{
    static public void Main(string[] args)
    {
      // pe.Euler1(1000);    //  sumThreesAndFivesBelowLimit()
      // pe.Euler2(4000000); //  sumEvenFibonaccisBelowLimit()
      // pe.Euler3(600851475143); //  maxPrimeFactor()      // 70secs w/netbook
      // pe.Euler4(3);      //  findMaxPalindromeForN()
      // pe.Euler5(20);     //  getLeastCommonDividend();
      // pe.Euler6(100, 2);  //  powerOfSumMinusSumOfPowers()
      // pe.Euler7(10001);    //  getNthPrime()

      pe.Euler8(data.SERIES_EIGHT, 4);    // -> 5832
      pe.Euler8(data.SERIES_EIGHT, 13);   // largestProductInSeries() // 23,514,624,000
      pe.Euler9(1000);   // largestProductInSeries()
    }
}
