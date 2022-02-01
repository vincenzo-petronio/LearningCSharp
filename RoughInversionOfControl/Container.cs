namespace RoughInversionOfControl
{
    internal class Container
    {
        private readonly Dictionary<string, object> configuration = new();
        private readonly Dictionary<Type, Creator> typeToCreator = new();
                
        public delegate object Creator(Container container);

        public Dictionary<string, object> Configuration
        {
            get { return configuration; }
        }

        public T GetConfiguration<T>(string name)
        {
            return (T)configuration[name];
        }

        public void Register<T>(Creator creator)
        {
            typeToCreator.Add(typeof(T), creator);
        }

        public T Create<T>()
        {
            return (T)typeToCreator[typeof(T)](this);
        }
    }
}
