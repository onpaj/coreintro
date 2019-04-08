namespace DI
{
    public class ServiceDecorator : IService
    {
        private readonly IService _decorated;

        public ServiceDecorator(IService decorated)
        {
            _decorated = decorated;
        }
    }
}