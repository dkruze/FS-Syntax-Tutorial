(*
The following function computes the factorial of a number, recursively
Expected input: integer x
Expected output: long in the form of a recursive call
*)
let rec factorial x : int64 = //accept an integer, return a long
 if x = 0 //does not allow negative factorials
  then 1 //0! = 1
 else //for positive values
  (int64) x * factorial (x - 1) //x! = x * (x-1)!--note that this is typecast to a long

let stopWatch = System.Diagnostics.Stopwatch.StartNew() //integrated library object that allows for a stopwatch in milliseconds

(*
The following function calculates the combination nCr = n!/(r!(n-r)!) of a set, given size and number of combination elements
It includes a lazy reference to the divisor of this formula, that does not execute until needed by a separate declaration
This allows us to check that the parameters are valid (do not allow negative factorials) after factorizing the formula
This prevents a stack overflow, and can also be up to 8 times faster than traditional exception handling
Expected input: two integers n, r
Expected output: string message to the command line
*)
let combination n r : unit = //accept two parameters, return a unit (call to a function or object)
 let m = n - r // let m be a factor of the combination calculation
 let o = lazy ((factorial r) * (factorial m)) // let o be a lazy reference to the divisor of the calculation--this cannot contain negative values
 if m < 0 //if negative factorials are calculated, notify the user that they are using invalid parameters
  then printfn "Combination Fault: More elements in combination than elements in the set!\nTry invoking \"combination n r\" such that n >= r.\n"
 else //if all factorials are valid
  if n = r //if all members of the set are included in the combination, only one combination exists
   then printfn "%d Combination exists of %d members in a set of %d elements.\n" ((factorial n) / (o.Force())) r n
  else //otherwise, print the number of combinations
   printfn "%d Combinations exist of %d members in a set of %d elements.\n" ((factorial n) / (o.Force())) r n

let result1 = combination 20 15 //combinations of 15 out of 20
let result2 = combination 20 25 //invalid combination--ordinarily causes a stack overflow
let result3 = combination 20 20 //combination of 20 out of 20

stopWatch.Stop() //stop the stopwatch object
printfn "%fms" stopWatch.Elapsed.TotalMilliseconds //print out the amount of milliseconds since the above calculation began