# AddressHelpers

This library provides a method which reveals the actual address of an instance
of a class or value object.


## Examples

To get the address of a class, we can use the GetAddress() method of AddressExtensions,
which is

```
var someClass = new SomeClass();
var address = AddressExtensions.GetAddress(someClass);
```

Value types are a bit trickier, though, because we must take care to pass a reference
instead of a copy of that object. The following example shows how to get the stack
address of a value type:

```
var someValue = 42;
var address = AddressExtensions.GetAddress(ref someValue);
```

or for that matter, even complex value types, i.e. structs:

```
var someStruct = new SomeStruct();
var address = AddressExtensions.GetAddress(ref someStruct);
```