using System;
using System.Runtime.Serialization;

namespace VILA2._0.Servicos
{
    [Serializable]
    internal class DbConcurrencyException : Exception
    {
        public DbConcurrencyException()
        {
        }

        public DbConcurrencyException(string message) : base(message)
        {
        }

        public DbConcurrencyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DbConcurrencyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}