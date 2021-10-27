namespace CSharp_Utils
{
    namespace Java
    {
        class Either<L, R>
        {
            Optional<L> LeftValue;
            Optional<R> RightValue;

            private Either() { }
            private Either(L value) { this.LeftValue = new Optional<L>(value); }
            private Either(R value) { this.RightValue = new Optional<R>(value); }

            public bool IsLeft() { return LeftValue != null; }
            public bool IsRight() { return RightValue != null; }

            public L GetLeft() {
               return this.LeftValue.Get();
            }
            public R GetRight() {
               return this.RightValue.Get();
            }

            public static Either<L, R> Left(L value)
            {
                return new Either<L, R>(value);
            }

            public static Either<L, R> Right(R value)
            {
                return new Either<L, R>(value);
            }
        }
    }
}