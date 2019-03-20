using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaAndTheLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lammbda and the LINQ");

            // here are some variables to use as needed
            int a = 2;
            int b = 5;
            int c = 0;

            // consider the following expression:
            int Multiply(int x, int y) { return x * y; }

            // use it a few times .... and you may use Say(,,) to print the results onto the Console
            c = Multiply(5, 6);
			Say(c, 5, 6); // my example




            // Delete the "/* at the start of this line to activate the next section
            // we are going to define a function/delegate that takes two integers and returns an integer
            // and we will call it MultipleDelegate.  MultipleDelegate is now a function that holds the
            // delegate we give it, but it is null until we give it one.
            Func<int, int, int> MultiplyDelegate;

            // we will assign our Multiply method to it.  Func<> handles all the assumptions, assertions, and implied operations
            MultiplyDelegate = Multiply;

            // use MultiplyDelegate a few times .... and you may use Say(,,) to print the results onto the Console
            c = MultiplyDelegate(8, 9); Say(c, 8, 9); // my example




            
            /// Delete the "/* at the start of this line to activate the next section
            // We are going to make a new function which will use a lambda expression rather than a delegate
            // Lambda's format is       elements => statements to process elements
            // Here the elements are two integers x and y and we (imply we will) return an integer using the multiply expression
            Func<int, int, int> MultiplyingLambda = (x, y) => (x * y);

            // use MultiplyingLambda a few times .... and you may use Say(,,) to print the results onto the Console
            c = MultiplyingLambda(11, 3); Say(c, 11, 3); // my example



            
             // Delete the "/* at the start of this line to activate the next section
             // LINQ
             // 
             // Language INtegrated Query uses SQL-like syntax to perform operations but not necessarily on a database.
             // LINQ will examine the parameters given it and on the types of those parameters and
             // over a series of invisible steps utilize overload methods for operations on the parameters, convert
             // those parameters into anonymous types to pass between the steps, and anonymous methods on the parameters
             // or anonymous types.  If multiples of parameters are given LINQ expression then a collection of results will be produced.
             // The "var" designation is often used for the results of a LINQ expression because the actual type of the results
             // may not be what you expect but can be cast into something more expected that you can use.  Additionally, LINQ statements
             // use "deferred execution" in that they are not evaluated until run-time and the results of each individual result is not
             // produced until it is needed.  For a list of results, each individual result has its execution deferred until it is needed.
             
            // Here is a list of integers to work with:
            var listOfIntegers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11,12,13,14,15,16,17,18,19,20 };

            // here is a LINQ statement with LINQ keywords "from", "in", "where", and "select".  Use Shout() to print integers out.
            // our smallerNumbers collection is actually of type "System.Collections.Generic.IEnumerable<int>" and not List<int>
            var smallerNumbers = from num in listOfIntegers where num < 6 select num;
            Shout(smallerNumbers);
            // You could say "from each number in a listOfIntegers where they are < 6, and select them all to be returned in a list".

            // this does the same thing but we are using List<> methods ".Where" and ".Select" with lambdas as parameters
            var smallNumbers = listOfIntegers.Where(n => n < 6).Select(n => n);
            Shout(smallNumbers);
            // You could say "given a listOfIntegers, find the ones where they are < 6 and select each to return into a list".
            // The sentences describing each is slightly different but in each describes what occured.
            //
            DashedLine(); // Lets do some more ...

            /// Delete the "/* at the start of this line to activate the next section
            // LINQ also can look at the details of the types it work with.  Here is a very complex example:
            var methods = from method in typeof(int).GetMethods()
                          orderby method.Name
                          group method by method.Name into groups
                          select new { MethodName = groups.Key, MethodOverloads = groups.Count() };
            foreach (var item in methods) { Console.WriteLine(item); }
            // Wow!  LINQ keywords were "from", "in", "orderby", "group", "by", "into", and "select".
            // C# keywords "typeof()", and "new".
            // Notice the use of vars for "method" and "item" to make this easier to read and work with.
            //
            // LINQ has some additional Key Operators:
            // Any()      - Returns a boolean of whether a (collection) is empty or not.
            // Take()     - Allows the selection of a certain number of elements (Take this number).
            // Distint()  - Filters out result to only distint ones (removes duplicates).
            // Zip()      - Combines two result lists together like a zipper on a jacket.
            // // Here some lists:
            var states = new List<string> { "Colorado", "California", "Alaska", "Hawaii", "Arizona" };
            var capitols = new List<string> { "Denver", "Sacramento", "Juneau", "Honalulu", "Phoenix" };
            var abbreviations = new List<string> { "CO", "CA", "AK", "HI", "AZ" };
            var fewerIntegers = new List<int> { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            var lackOfIntegers = new List<int>();

			// LINQ away with these lists, your own lists, and other types.  Use each Key Operator.
			// You can link some results (as demonstrated) using "." and  more keywords and operators.
			// You can make list subsets, combine lists, check for values, sort, and many other things.
			var first = from listOfStates in states
						orderby listOfStates.Length
						select listOfStates;
			foreach (var state in first)
			{
				Console.WriteLine(state);
			}
			
			//Shout(first);











            // states.Zip(abbreviations, (x,y) => $"{x} : {y}");
            // ///////////////////////////////////////////////////////////////// //
            /* */ ////////////////////////////////////////////////////////////// //
            DashedLine(); Console.ReadLine(); // stops terminal window from closing on us
        }

        // useful method to quickly print to the console the result of our multiplcations
        static void Say(int c, int a, int b) { Console.WriteLine($"{c} = {a} X {b}"); }
        static void Shout(System.Collections.Generic.IEnumerable<int> list)
        {  foreach (int a in list) { Console.Write($"{a},"); }; Console.WriteLine(); }
        static void DashedLine() { Console.WriteLine("------------------------------------------"); }
    }
}
