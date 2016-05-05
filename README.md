# cSharp.Monads
# WIP
Started with implementation of Monads in C#. 
This first commit contains the implementation of Optional type in C#

What is Optional Type?
Optional type represents a type which may or may not return a value. This type is mainly useful while returning value from methods. In case of simple type caller may or may not handle the null/empty values but in case of optional caller will know that the functioncan return null and it needs to handle that. 

In my implementation, I have not provided a simple Get method on Optional because I feel that we should make it compulsory to use HasValues, ifPresent or GetOrElse methods to the caller in order to prevent side effects of using simple Get.
