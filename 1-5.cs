class OneThroughFive
    {
        static void getOut (int num, int output)
        {	System.Diagnostics.Debug.WriteLine("Solution " + num + " is: " + output);	}

		
		//  1. Find the sum of all multiples of 3 or 5 below 1000.
		public void EulerOne (int theLimit)
		{	int sum = 0;
			int limit = theLimit;
            for (var i = 1; i < limit; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }
            getOut(1, sum);
   
		}
		
		//  2. Find the sum of the even terms in the Fibonacci subsequence below 4m.
		public void EulerTwo (int theLimit) {
            sum = 2;  						//  Skip the first, special case
            limit = theLimit;
            var g,h = 1,2;
            for (var i = 3; i < limit; i = g+h)
            {	if (i % 2 == 0)
					sum += i;
				
                g = h;
                h = i;
            }
            getOut(2, sum);

		}
		
		//  3. Largest prime factor of 600851475143
		public void EulerThree (int target) {
            long source = target;
            List<int> factors = new List<int>();
            List<int> primes = new List<int>();
            for (var i = 2; i < Math.Sqrt(source); i++)
            {
                if (!primes.Exists(p => i % p == 0))
                {
                    if (source % i == 0)
                    {
                        factors.Add(i);
                    }
                    primes.Add(i);
                }
            }
            getOut(3, factors.Last());
        }
		
		
        static void Main(string[] args)
        { 
			EulerOne(1000);
			EulerTwo(4000000);
			EulerThree(600851475143);
        }
    }
}