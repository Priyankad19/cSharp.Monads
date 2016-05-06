using cSharp.Monads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monads.NET
{
    public class Either<L, R>
    {
        private Optional<L> leftValue;
        private Optional<R> rightValue;

        private Either(Optional<L> leftValue, Optional<R> rightValue)
        {
            this.leftValue = leftValue;
            this.rightValue = rightValue;
        }

        /// <summary>
        /// Assigns Left value and makes right value None
        /// </summary>
        /// <param name="leftValue">Left value to be assigned</param>
        /// <returns>Instance of Either<L,R>"</returns>
        public static Either<L, R> Left(L leftValue)
        {
            return new Either<L, R>(leftValue, new None<R>());
        }

        /// <summary>
        /// Assigns right value and makes left value None
        /// </summary>
        /// <param name="rightValue">Right value to be assigned</param>
        /// <returns>Instance of Either<L,R>"</returns>
        public static Either<L, R> Right(R rightValue)
        {
            return new Either<L, R>(new None<L>(), rightValue);
        }

        /// <summary>
        /// Calls either of the passed functions. 
        /// If Left value is present then left function will be called and if right value is present then right function will be called.
        /// </summary>
        /// <param name="leftFunction"></param>
        /// <param name="rightFunction"></param>
        public void Apply(Action<L> leftFunction, Action<R> rightFunction)
        {
            leftValue.IfPresent(leftFunction);
            rightValue.IfPresent(rightFunction);
        }
        
    }

}
