namespace DependncyInjectionSample.DiSample
{
    public class DiChainSample : IDiChainSample
    {
        private readonly Guid _id;

        public DiChainSample()
        {
            _id = Guid.NewGuid();
        }

        public string GetChainGuid()
        {
            return _id.ToString();
        }
    }
}
