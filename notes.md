## Basics

### Classes

class hanya bisa inherit 1 to prevent diamond problem

## Advanced C#

### Delegates

Delegates exist to provide a type-safe mechanism for treating methods as first-class objects. They allow methods to be assigned to variables, passed as arguments, and returned from other methods, which is essential for writing decoupled, functional, and event-driven code without the heavy boilerplate of interfaces.

objek yg bisa manggil method 
nyimpen alamt memori dari method

ex:
delegate int Transformer(int x)

fungsinya biar bisa plug-in method, manggil method kayak callback di javascript

static dan instance sama

bisa numpuk method, trigger scr urut, namanya multicast

kalo ada returnnya yg direturn yg method terakhir, lainnya ttp jalan tpi ga return

best practice delegate buat method void

delegate itu immutable, bikin objek baru tiap nambah

bisa bikin delegate yg generic pake T

di c# ada built-in delegate -> Func dan Action
Func kalo ada return type,
Action yg void,

Under the hood, delegates are objects allocated on the Heap that inherit from System.MulticastDelegate. To execute an instance method, the delegate stores two critical references: the Method (a MethodInfo object representing the compiled IL code) and the Target (a strong reference to the specific object instance the method belongs to). For static methods, the Target is null.

In delegates, return types are covariant (out), meaning a method can return a more derived (specific) type than the delegate signature defines. Parameters are contravariant (in), meaning a method can accept parameters that are less derived (more general) than what the delegate signature specifies.

pake delegate kalo:
- kalo single method interface
- multicast capability
- multiple implementation by subscriber

compatibility

### Events

wrapper mlticast delegate, utk ngefire suatu event

dari delegate muncul: publisher dan subscriber

tujuannya utk prevent subscriber biar ga ngutak atik

ada standard event patternnya

Think of an event exactly like a C# property: where a property encapsulates a private variable with get and set methods to restrict raw data manipulation, an event encapsulates a private delegate instance with add and remove methods to prevent external code from clearing or blindly overwriting the subscriber list

byk dipake di pembuatan desktop app, winform dll

For a class that exposes dozens of events (e.g., a complex UI control) where most events remain unsubscribed, what architecture pattern can you implement to optimize memory allocation, rather than having dozens of null delegate backing fields?
- You can implement "Sparse Events". Instead of relying on the compiler to generate individual private backing fields for every event, you explicitly implement the event accessors (add and remove) and store only the active delegates in a centralized collection, such as a Dictionary<string, Delegate>. This drastically reduces the memory footprint per instance.

The event keyword adds a layer of encapsulation. Without it, an outside class could directly invoke the delegate, overwrite all existing subscribers by using the = operator, or set the delegate to null. The event keyword ensures that external subscribers can only add (+=) or remove (-=) themselves, preventing interference with other subscribers.


### try Statements and Exceptions

try catch block

try 
catch -> handle error, exceptions
finally -> always excute, cleanup code

expensive di performance

ex: bikin global handling di web api

exception paling specific di awal catch, general di akhir

constraint
- when filter

file itu unmanage resources, gaada GC nya

bisa disingkat pake keyword using biar auto dispose

trigger exception manual pake throw new keyword, downsidenya performance lbh tinggi di cpu atau memori

bisa rethrow di dlm catch

aggregate exception utk nyimpen stack trace errornya yg banyak

the TryXXX Method Pattern, lbh defensif
ex: int.TryParse()

### Enumerations and Iterators

enumeration: proses utk menjelajahi sebuah collection
iterator: struct lang nya biar enumerations gampang, pake yield

enumerator, objek utk jelajahi objek, low levelnya, interfacenya
enumerable, wrapper dari IEnumerator, biar bisa traverse objeknya scr mandiri

foreach, high levelnya

### Nullable Value Types

int? x = null //implicit

btsnya ? adalah struct Nullable, wrappernya 

int? x = 5;
int y = (int)x; // Explicit conversion from int? to int

nullable ga define operator, jadinya ada operator lifting di btsnya

bisa mix nullable sama engga

ex: sering pas connect dg database

### Operator Overloading

buat bikin custom operator dalam class atau struct, not best practice tho

hampir semua operator bisa dioverload
