namespace OrderService.Application.Exceptions
{
    public class ClientErrorMessage : ApplicationException
    {
        private readonly string _message;

        public ClientErrorMessage(string message) : base(message)
        {

        }


    }
}
