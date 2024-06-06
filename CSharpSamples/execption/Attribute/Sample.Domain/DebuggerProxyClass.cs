namespace Sample.Domain
{
    public class DebuggerProxyClass
    {
        private readonly Person _person;

        public DebuggerProxyClass(Person person)
        {
            _person = person;
        }

        public string FullName => $"{_person.FirstName} {_person.LastName}";
    }
}