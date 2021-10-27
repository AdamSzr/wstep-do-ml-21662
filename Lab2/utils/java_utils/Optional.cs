using System;

namespace CSharp_Utils
{
    namespace Java
    {
    class Optional<T>
        {
            private T value;

            public Optional(T value)
            {
                this.value = value;
            }

            public T Get()
            {
                //if ((this.value is object))
                   // Console.WriteLine(value.ToString());

                return this.value == null ?
                    throw new Exception("Value of optional is null") :
                    this.value;
            }

            public bool IsPresent()
            {
                if ((this.value is object))
                 //   Console.WriteLine(value.ToString());

                return (this.value is object);
                return true;
            }

            public static Optional<Object> Empty()
            {
                return new Optional<Object>(null);
            }

            public T GetOrElse(Func<T> back)
            {
                return this.value == null ? back() : value;
            }

            public override bool Equals(Object obj)
            {
                if (obj == null || this.value.GetType() != obj.GetType())
                {
                    return false;
                }

                return Object.Equals(this, obj);
            }

            public override int GetHashCode()
            {
                return 1;
            }


        }
    }

}
