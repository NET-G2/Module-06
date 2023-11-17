namespace DiyorMarket.Domain.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException() { }
        public EntityNotFoundException(string message) { }
        public EntityNotFoundException (string message, Exception innerException) { }
        public EntityNotFoundException(string message, string entityType) { }
    }
}
