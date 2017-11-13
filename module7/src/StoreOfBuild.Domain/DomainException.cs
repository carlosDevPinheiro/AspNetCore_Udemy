using System;

namespace StoreOfBuild
{
    public class DomainException: Exception
    {
        public DomainException(string error): base(error) {  }

        public static void When(bool valid, string error)
        {
            if(!valid)
             throw new DomainException(error);
        }
    }
}