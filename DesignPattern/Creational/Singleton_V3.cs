using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPattern.Creational.Singleton_V3
{
    //WHY Singleton Pattern is called AntiPattern?

    //https://dev.to/emrahsungu/singleton-pattern-implemented-in-c-e9

    public abstract class SingletonBase<T>
    {

        /// <summary>
        /// Instance creator for this class. <see cref="Lazy{T}" /> guarantees
        /// that <see cref="InstanceCreator" /> will only run once.
        /// </summary>
        private static readonly Lazy<T> LazyInstance = new Lazy<T>(InstanceCreator);

#if DEBUG

        /// <summary>
        /// Counter which holds how many instances this class has.
        /// Since this is a Singleton implementation,
        /// <see cref="_instanceCount" /> can at most be one (1).
        /// </summary>
        private static int _instanceCount;

#endif

        /// Every Singleton implementation is required to inherit this base class.
        protected SingletonBase()
        {
#if DEBUG
            Interlocked.Increment(ref _instanceCount);
            if (_instanceCount > 1)
            {
                throw new Exception($"{nameof(T)} is Singleton but it has {_instanceCount} instances");
            }
#endif
        }

        /// <summary>
        /// Access the instance of this Singleton. The first time you access
        /// it is lazily instantiated.
        /// </summary>
        /// <remarks>This property must be thread-safe.</remarks>
        public static T Instance => LazyInstance.Value;

        /// <summary>
        /// </summary>
        /// <returns>An instance of <see cref="T" /></returns>
        private static T InstanceCreator()
        {
#if DEBUG
            var ctors = typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            var publicCtors = ctors.Where(c => c.IsPublic);
            if (publicCtors.Any())
            {
                throw new HasPublicConstructorException(typeof(T));
            }

            var ctorsWithParameters = ctors.Where(c => c.GetParameters().Length > 0);
            if (ctorsWithParameters.Any())
            {
                throw new HasConstructorWithParametersException(typeof(T));
            }
#endif
            //Since this will be run only once during the application's life cycle it is acceptable to use.
            //If it would be called many times, it is better to CreateDelegate
            return (T)Activator.CreateInstance(typeof(T), true);
        }
    }

    [Serializable]
    internal class HasConstructorWithParametersException : Exception
    {
        private Type type;

        public HasConstructorWithParametersException()
        {
        }

        public HasConstructorWithParametersException(Type type)
        {
            this.type = type;
        }

        public HasConstructorWithParametersException(string message) : base(message)
        {
        }

        public HasConstructorWithParametersException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected HasConstructorWithParametersException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    internal class HasPublicConstructorException : Exception
    {
        private Type type;

        public HasPublicConstructorException()
        {
        }

        public HasPublicConstructorException(Type type)
        {
            this.type = type;
        }

        public HasPublicConstructorException(string message) : base(message)
        {
        }

        public HasPublicConstructorException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected HasPublicConstructorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    internal class AlreadyRegisteredTypeException : Exception
    {
        private Type type;

        public AlreadyRegisteredTypeException()
        {
        }

        public AlreadyRegisteredTypeException(Type type)
        {
            this.type = type;
        }

        public AlreadyRegisteredTypeException(string message) : base(message)
        {
        }

        public AlreadyRegisteredTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AlreadyRegisteredTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    internal class NotRegisteredTypeException : Exception
    {
        private Type type;

        public NotRegisteredTypeException()
        {
        }

        public NotRegisteredTypeException(Type type)
        {
            this.type = type;
        }

        public NotRegisteredTypeException(string message) : base(message)
        {
        }

        public NotRegisteredTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotRegisteredTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }


    public class SingletonManager : SingletonBase<SingletonManager>
    {
        private readonly Dictionary<Type, Lazy<object>> _cache = new Dictionary<Type, Lazy<object>>();

        //Classes implementing SingletonBase<T> can be registered at SingletonManager
        private SingletonManager()
        {
        }

        //Registers the given type to SingletonManager
        public void Register<T>() where T : SingletonBase<T>
        {
            if (_cache.ContainsKey(typeof(T)))
            {
                throw new AlreadyRegisteredTypeException(typeof(T));
            }
            _cache[typeof(T)] = new Lazy<object>(() => SingletonBase<T>.Instance);
        }

        public T Get<T>() where T : SingletonBase<T>
        {
            if (_cache.TryGetValue(typeof(T), out var value))
            {
                return (T)value.Value;
            }
            throw new NotRegisteredTypeException(typeof(T));
        }
    }
    public interface IGameManager
    {
        void Initialize();

        void Update();

        void Destroy();
    }
    public abstract class GameManagerBase<T> : SingletonBase<T>, IGameManager
    {
        protected GameManagerBase()
        {
        }

        public abstract void Initialize();

        public abstract void Update();

        public abstract void Destroy();
    }


    public class Client
    {
        public static void Execute()
        {
            var manager = SingletonManager.Instance;
            //manager.Register<CutSceneManager>();
            //manager.Get<CutSceneManager>().Initialize();
            //manager.Get<CutSceneManager>().Update();
        }
    }

  
}