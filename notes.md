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

an iterator is a method, property, or indexer that produces an enumerator

enumerator, the cursor atau objek utk jelajahi objek, low levelnya, interfacenya
enumerable, the sequence, wrapper dari IEnumerator, biar bisa traverse objeknya scr mandiri

foreach, high levelnya

### Nullable Value Types

int? x = null //implicit

btsnya ? adalah struct Nullable, wrappernya

int? x = 5;
int y = (int)x; // Explicit conversion from int? to int

nullable ga define operator, jadinya ada operator lifting di btsnya

bisa mix nullable sama engga

ex: sering pas connect dg database

While a standard int requires 4 bytes, an int? requires 8 bytes. The System.Nullable<int> struct contains an int (4 bytes) and a bool (1 byte). Due to memory alignment rules and CPU architecture padding (to ensure data is read in efficient chunks), the CLR pads the struct to 8 bytes.

### Operator Overloading

buat bikin custom operator dalam class atau struct, not best practice tho

hampir semua operator bisa dioverload

## Framework Fundamentals

### String and Text Handling: Working with Character Data

char: a single unicode character, 16 bit value, encoding UTF-16, bisa diubah ke UTF-8 for performance

string: immutable (unchangeable) sequences of characters. Replace, Substring returns a new string.

- bisa pake string builder for performance
- string bisa null, karna ref type
- can be accessed by index
- implement IEnumerable
- can be searched with built-in methods
- can be manipulated with methods
- split, join
- interpolation
- can be compared equality and order
- string builder: mutable string for performance
-

### Dates and Times

- value type, masuk dlm struct
  Because these are structs (value types), they are allocated on the stack or inline within objects, which avoids heap allocation and garbage collection overhead; consequently, they are not intrinsically nullable.
  They are immutable structs, meaning their values cannot change after they are created.
  Under the hood, they operate on a high-precision 100 nanosecond (ns) resolution.
  This resolution is tracked via a long representing "ticks", where each tick equals 100ns.
- operator arithmetic dah di overload jadi mudah calculate time
- default value TimeSpan.Zero
- DateTime and DateTimeOffset, utk tanggalan, offset yg ada +- utcnya
- dah banyak methods
- formatter and parser
- kalo null pake nullablenya
- start .net 6 bisa get dateonly & timeonly

TimeSpan represents an interval of time or duration.
DateTime and DateTimeOffset represent specific points in time.
DateTimeOffset specifically solves absolute time mapping by storing explicit offsets from UTC.

### Formatting and Parsing

- format: object to string
- parsing: string to object
- format provider for more control, pake IFormattable
- bisa bikin format provider sendiri ICustomFormatter

### Other Conversion Mechanisms

- ada Convert class selain ToString() dan Parse()

### Working with Numbers

- BigInt
- Half for performance, cant use operator, +-65500
- Complex for imaginer number
- Random, random number generators, dibilang pseudo random karna ada seednya (rangenya), best practicenya satu random di 1 project
- true randomnese pake Cryptographic
- BitOperations

### Enums in .NET

- type unification
- provide static method
- can be casted, explicit
- can be looped

### Equality Comparison

- class perbandingan by ref

### Utility Classes

- Environment class, local machinenya
- Process class
- Console class
- AppContext class, informasi program yg kita jalani

## Collections

### Enumeration

- IEnumerator and IEnumerable
- kpn pake non generic: kalo type unification, kyk any, hrs ada boxing unboxing
- yield return pas pake enumerator

### Array Class

- base class dari tiap array yg kita bikin
- contiguous memory, di heap letaknya sebelhan, fixed size
- kalo ngerubah size, btsnya ngecopy array lama trs bikin array baru
- storagenya: kalo value type ya ttp di heap tpi isinya value, kalo ref type ya alamat memorinya
- buat clone pake Clone(), shallow copy

### Lists, Queues, Stacks, Dictionary, and Sets

- Dictionary: collection <key, value> pair
- List: array yg dynamic sized
- LinkedList: Doubly Linked Lists
- Queue: antrian, FIFO
- Stack: tumpukan, LIFO
- BitArray: isinya false true
- HashSet: unique item, no duplicate
- SortedSet: HashSet yg urut

### Customizable Collections and Proxies

- class ngecustom collection
- KeyedCollection for Dictionary
- ReadOnlyCollection: biar collection read only biar safety

### Immutable Collection

- collection yg gabisa diubah, for concurrency and multithread biar akses ke datanya ga acak2 atau beda2
- easier debug, reduced bugs
- jeleknya dia lemot
- Builder for efficiency

### Plugging in Equality and Order

- bikin custom comparer, tanpa ngutak atik classnya
- pake IEqualityComparer
- versi builtin nya: StringComparer
- bandingin struktural: IStructuralEquatable dan IStructuralComparable

## Disposal & Garbage Collection

Objek yg dimanage: new() yg diinstantiate

ada yg ga dimanage: http

ada 2 tipe:
- managed resource -> Object
- unmanaged resource -> DB connection, HTTP, file handling, stream

### IDisposable, Dispose, and Close

nyediain 1 method Dispose() utk cleanup unmanaged resource

`using` statement, btsnya ada try finally block

syarat:
- disposalnya irreversible
- idempotent disposal, kalo trigger berulang ga masalah
- ownershp and chained disposal, 

Close() and Stop(), bisa diopen kembali, use case di DB connection
Stop di timer atau http listener

kapan utk dispose? if in doubt, dispose

jangan dispose:
- when you dont own the object
- kalo bakal ada unwanted actions
- unnecessary by design, adds complexity

di dispose itu:
- ngeclear reference
- unsubs from Events supaya ga OutOfMemoryException
- ngeset IsDisposed flag
- clear event handlers
- clear sensitive data (kartu kredit dll)

### Automatic Garbage Collection

might trigger GC:
- available memory
- Amount of memory allocation
- time since last collection

dibagi jadi 3 gen:
- gen 0, newly allocated object, paling sering,
- gen 1, yg lwt dari gen 0 naik ke gen 1, jarang2
- gen 2, yg survice gen 1 ke gen 2, objeknya yg long lived, di atas 100ms

short lived object is quicker to cleanup than long lived

### Finalizers

last resort cleanup, ditrigger sblm GC jalan

`~Test()`

- gaboleh public or static


cara kerja:
- pas GC jalan bakal identify, misahin
- segregation
- sblm gc jalan, finalizers akan jalan

use case finalizers utk last resort dispose

bukan best practice utk dipakai kecuali emg butuh dan dg byk aturan

### How GC Works

pake generational collection agar optimize

### Managed Memory Leaks

- event handlers
- timer

ada profiling tools utk mantau memorynya

### Weak References

bisa bikin object agar bisa mudah utk diclean GC

use case: 
- utk ngetrack object
- caching

## Diagnostics and Code Contracts

### Conditional Compilation

use case:
- pake namespace tertentu dan pgn ganti2, kyk env di dev staging or prod

### Debug and Trace Classes

utk logging

debug di debug build
trace di debug dan release build

### Assertions