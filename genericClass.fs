type cubeClass<'a>(_name : 'a, _x : 'a, _y : 'a, _z : 'a) = //define a generic class with four non-specific parameters
 let mutable name = _name //name of the cube
 let mutable length = _x //length of the cube
 let mutable width = _y //width of the cube
 let mutable height = _z //height of the cube
 do printfn "Cube \"%A\" initialized with length %A, width %A, and height %A\n" name length width height //when class is instantiated, print its properties
 member this.Name with get() = name and set(value) = name <- value //getter/setter for name
 member this.Length with get() = length and set(value) = length <- value //getter/setter for length
 member this.Width with get() = width and set(value) = width <- value //getter/setter for width
 member this.Height with get() = height and set(value) = height <- value //getter/setter for height
 member this.volume(b: int) = //define a method for the volume of a cube
  3 * b //volume = l*w*h
 member this.surface(c: int) = //define a method for the surface area of a cube
  6 * (c * c) //surface area = 6*w^2
 member this.volumeDef(d: string) = //define a method to print the definition for the volume formula of a cube
  "Volume = " + d + " times " + d + " times " + d //volume = l*w*h
 member this.surfaceDef(e: string) = //define a method to print the definition for the surface area formula of a cube
   "Surface Area = 6(" + e + "^2)" //surface area = 6*w^2

type Dlgt1 = delegate of int -> int //delegate type for volume method, a method that accepts an int and returns an int
type Dlgt2 = delegate of int -> int //delegate type for surface area method, a method that accepts an int and returns an int
type Dlgt3 = delegate of string -> string //delegate type for volume definition method, a method that accepts a string and returns a string
type Dlgt4 = delegate of string -> string //delegate type for surface area definition method, a method that accepts a string and returns a string

let invokeDlgt1 (dlg : Dlgt1) (a : int) = //invocation function for a method; accepts a Dlgt1 and an integer
 dlg.Invoke(a) //call the integrated Invoke() method on integer a, which passes a to a function of type Dlgt1
let invokeDlgt2 (dlg : Dlgt2) (a : int) = //invocation function for a method; accepts a Dlgt2 and an integer
 dlg.Invoke(a) //call the integrated Invoke() method on integer a, which passes a to a function of type Dlgt2
let invokeDlgt3 (dlg : Dlgt3) (a : string) = //invocation function for a method; accepts a Dlgt3 and a string
 dlg.Invoke(a) //call the integrated Invoke() method on string a, which passes a to a function of type Dlgt3
let invokeDlgt4 (dlg : Dlgt4) (a : string) = //invocation function for a method; accepts a Dlgt4 and a string
 dlg.Invoke(a) //call the integrated Invoke() method on string a, which passes a to a function of type Dlgt4

let blockHead = cubeClass<int>(1, 2, 2, 2) //instantiate an object of cubeClass with integers
let wigglyWorld = cubeClass<string>("two", "two", "two", "two") //instantiate an object of cubeClass with strings

let objDlgt1 = Dlgt1(blockHead.volume) //instantiate an object of Dlgt1 with the integer volume method
let objDlgt2 = Dlgt2(blockHead.surface) //instantiate an object of Dlgt2 with the integer surface area method
let objDlgt3 = Dlgt3(wigglyWorld.volumeDef) //instantiate an object of Dlgt3 with the string volume definition method
let objDlgt4 = Dlgt4(wigglyWorld.surfaceDef) //instantiate an object of Dlgt4 with the string surface area definition method

(*
Note that in the below blocks, the invocation function we defined above is being passed two things--an object and property
The object we pass it must be of the same type expected by the function itself, and the property must also follow suit
*)
let volume1 = invokeDlgt1 objDlgt1 blockHead.Length //variable representing the invocation of the volume function with integer length
printfn "Volume of Cube %d: %d" blockHead.Name volume1 //print the integer volume of the cube
let surface1 = invokeDlgt2 objDlgt2 blockHead.Length //variable representing the invocation of the volume function with integer length
printfn "Surface Area of Cube %d: %d\n" blockHead.Name surface1 //print the integer surface area of the cube
let volume2 = invokeDlgt3 objDlgt3 wigglyWorld.Length //variable representing the invocation of the volume function with integer length
printfn "Volume of Cube %s: %s" wigglyWorld.Name volume2 //print the string volume of the cube
let surface2 = invokeDlgt4 objDlgt4 wigglyWorld.Length //variable representing the invocation of the volume function with integer length
printfn "Surface Area of Cube %s: %s\n" wigglyWorld.Name surface2 //print the string surface area of the cube