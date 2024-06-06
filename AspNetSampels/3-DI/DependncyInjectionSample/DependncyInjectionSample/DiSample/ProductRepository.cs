namespace DependncyInjectionSample.DiSample
{
    public class UserRepository : IUserRepository
    {
        private readonly Guid _guid;
        private readonly IDiChainSample _diChainSample;
        public UserRepository(IDiChainSample diChainSample)
        {
            _guid = Guid.NewGuid();
            _diChainSample = diChainSample;
        }

        public string GetGuid()
        {
            return _guid.ToString();
        }       

        public string GetChainGuid() => _diChainSample.GetChainGuid();
    }

    public class OrderRepository : IOrderRepository
    {
        private readonly Guid _guid;
        private readonly IDiChainSample _diChainSample;
        public OrderRepository(IDiChainSample diChainSample)
        {
            _guid = Guid.NewGuid();            
        }

        public string GetGuid()
        {
            return _guid.ToString();
        }        
    }
}
