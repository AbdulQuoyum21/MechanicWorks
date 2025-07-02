namespace Mechanic.Domain.Common
{
    public class BusinessLogicException : Exception
    {
        public BusinessLogicException()
        { }

        public BusinessLogicException(string message) : base(message)
        {
        }
    }
}