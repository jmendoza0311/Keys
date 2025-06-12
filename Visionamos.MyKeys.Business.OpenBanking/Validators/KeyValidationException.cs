using RabbitMQ.Client;

namespace Visionamos.MyKeys.Business.OpenBanking.Validators
{
    public class KeyValidationException : Exception
    { 
        public KeyValidationException(string message) : base(message) { }
        public KeyValidationException(string message, Exception inner) : base(message, inner) { }
    }
}

