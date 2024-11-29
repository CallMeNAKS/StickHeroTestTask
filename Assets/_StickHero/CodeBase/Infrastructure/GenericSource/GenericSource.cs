using UnityEngine;

namespace CodeBase.Infrastructure.GenericSource
{
    public abstract class GenericSource<T> where T : MonoBehaviour
    {
        protected T _prefab { get; private set; }

        public GenericSource(T prefab)
        {
            _prefab = prefab;
        }
        
        public abstract T Get();
    }
}