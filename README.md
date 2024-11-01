# AddressHelpers

This library provides a method which reveals the actual address of an instance
of a class or value object.


## Examples

To get the address of a class, we can use the GetAddress() method of AddressExtensions,
which is

```
var theInstance = new SomeClass();
var addressOfTheInstance = AddressExtensions.GetAddress(theInstance);
```

Value types are a bit trickier, though, because we must take care to pass a reference
instead of a copy of that object. The following example shows how to get the stack
address of a value type:

```
var someNumber = 42;
var addressOfSomeNumber = AddressExtensions.GetAddress(ref someNumber);
```

