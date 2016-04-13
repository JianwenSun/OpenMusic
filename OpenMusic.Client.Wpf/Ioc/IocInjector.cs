using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Wpf.Ico
{
    public class IocInjector
    {
        readonly IDictionary<Type, Type> types = new Dictionary<Type, Type>();
        readonly IDictionary<Type, object> implementationtypes = new Dictionary<Type, object>();

        public void Register<TInterface, TImplementation>()
            where TImplementation : TInterface
        {
            if (types.ContainsKey(typeof(TInterface)))
                types.Remove(typeof(TInterface));
            types[typeof(TInterface)] = typeof(TImplementation);
        }

        public void Register<TInterface>(object implementation)
        {
            if (implementationtypes.ContainsKey(typeof(TInterface)))
                implementationtypes.Remove(typeof(TInterface));
            implementationtypes[typeof(TInterface)] = implementation;
        }

        public void Register(Type type)
        {
            Register(type, type);
        }

        public void Register(Type type, Type implmentationType)
        {
            if (types.ContainsKey(type))
                types.Remove(type);
            types[type] = implmentationType;
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        public object Resolve(Type contract)
        {
            object value;
            if (implementationtypes.TryGetValue(contract, out value))
                return value;

            Type implementation = types[contract];
            ConstructorInfo constructor = implementation.GetConstructors()[0];
            ParameterInfo[] constructorParameters = constructor.GetParameters();

            if (constructorParameters.Length == 0)
            {
                return Activator.CreateInstance(implementation);
            }

            List<object> parameters = new List<object>(constructorParameters.Length);
            foreach (ParameterInfo parameterInfo in constructorParameters)
            {
                parameters.Add(Resolve(parameterInfo.ParameterType));
            }

            return constructor.Invoke(parameters.ToArray());
        }
    }
}
