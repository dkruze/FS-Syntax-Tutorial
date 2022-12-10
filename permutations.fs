let rec factorial x =
 if x < 1
  then 1
 else
  x * factorial (x - 1)

//standard implementation
let permutation n r : int =
 (factorial n) / (factorial (n - r))

let result1 = permutation 6 4
printfn "%d \n" result1

//compositional implementation
let f x : int =
 (factorial 6) / x

let g y: int =
 factorial (6 - y)

let h =
 g >> f

let result2 = h 4
printfn "%d \n" result2
 
//pipelining implementation
let A i: int =
 (factorial 6) / i

let B j: int =
 factorial (6 - j)

let result3 = 4 |> B |> A
printfn "%d" result3