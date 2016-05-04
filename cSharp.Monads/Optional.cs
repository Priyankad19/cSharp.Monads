using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cSharp.Monads
{

    public abstract class Optional<T>
    {
        // Could contain the value if Some, but not if None
        protected abstract T Value { get; }

        /// <summary>
        /// Returns true in case of Some otherwise false
        /// </summary>
        public abstract bool HasValue { get; }

        /// <summary>
        /// Get value. Not accessible outside this class forcing developers to use GetOrElse, HasValues or IfPresent. 
        /// This will prevent side effect of using just Get
        /// </summary>
        /// <returns></returns>
        private T Get()
        {
            return Value;
        }

        /// <summary>
        /// Get the value if present otherwise returns default value passed
        /// </summary>
        /// <param name="defaultValue">Default value</param>
        /// <returns>Returns value if present otherwise default value</returns>
        public T GetOrElse(T defaultValue)
        {
            if (HasValue)
                return Get();
            else
                return defaultValue;
        }

        /// <summary>
        /// Calls a function if the value is present otherwise does nothing
        /// </summary>
        /// <param name="consumerFunction">Function with one parameter of type T and no return type</param>
        public void IfPresent(Action<T> consumerFunction)
        {
            if (HasValue)
                consumerFunction(Value);
        }

        /// <summary>
        /// Implicit conversion of any type into optional type
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static implicit operator Optional<T>(T value)
        {
            if (value == null)
                return new None<T>();
            else
                return new Some<T>(value);
        }

        /// <summary>
        /// Explicitly convert Optional type to any given type
        /// </summary>
        /// <param name="value">Value to be converted</param>
        /// <returns></returns>
        public static explicit operator T(Optional<T> value)
        {
            return value.Value;
        }
    }

    public sealed class Some<T> : Optional<T>
    {
        private T value;
        public Some(T value)
        {
            // Setting Some to null, nullifies the purpose of Some/None
            if (value == null)
            {
                throw new System.ArgumentNullException("value", "Some value was null, use None instead");
            }

            this.value = value;
        }

        protected override T Value { get { return value; } }

        public override bool HasValue { get { return true; } }
    }

    public sealed class None<T> : Optional<T>
    {
        protected override T Value { get { throw new System.NotSupportedException("There is no value"); } }

        public override bool HasValue { get { return false; } }
    }
}
