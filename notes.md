## Basics

### Classes

class hanya bisa inherit 1 to prevent diamond problem

## Advanced C#

### Delegates

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

byk dipake di pembuatan desktop app, winform dll


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
