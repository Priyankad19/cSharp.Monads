# cSharp.Monads
# WIP
Basic implementation of Monads in C#. 

##Optional Type
Optional type represents a type which may or may not return a value. This type is mainly useful while returning value from methods. In case of simple type caller may or may not handle the null/empty values but in case of optional caller will know that the functioncan return null and it needs to handle that. 

In my implementation, I have not provided a simple Get method on Optional because I feel that we should make it compulsory to use HasValues, ifPresent or GetOrElse methods to the caller in order to prevent side effects of using simple Get.

##Either
The Either type represents values with two possibilities: a value of type Either a b is either Left a or Right b.

The Either type is sometimes used to represent a value which is either correct or an error; by convention, the Left constructor is used to hold an error value and the Right constructor is used to hold a correct value (mnemonic: "right" also means "correct"). 

I have implemented the use case of Either in [Notification Pattern](https://github.com/Priyankad19/NotificationPattern) example. This will give you fare idea of where and how to use Either.
