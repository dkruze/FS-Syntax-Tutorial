type squareClass(_x : int, _y : int) = 
 let mutable length = _x
 let mutable width = _y
 do printfn "Class initialized with length %d and width %d" length width
 member this.Length with get() = length and set(value) = length <- value
 member this.Width with get() = width and set(value) = width <- value
 member this.perimeter() =
  let presult = (this.Length * 4)
  printfn "Perimeter of square is %d" presult
 member this.area() = 
  let aresult = this.Length * this.Width
  printfn "Area of square is %d" aresult
 new() = squareClass(0, 0)

let blockHead = new squareClass(2, 2)
blockHead.perimeter()
blockHead.area()