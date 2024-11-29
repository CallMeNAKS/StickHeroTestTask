using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.Infrastructure.GenericSource.ObjectPool
{
    public class GenericObjectPool<T> : GenericSource<T> where T : MonoBehaviour
    {
        private List<T> _objects = new List<T>();

        public GenericObjectPool(T prefab) : base(prefab)
        {
        }

        public override T Get()
        {
            if (_prefab == null)
                throw new InvalidOperationException("Prefab is not set.");

            var pooledObject = _objects.FirstOrDefault(obj => !obj.gameObject.activeSelf) ?? CreateNewObject();
            return pooledObject;
        }

        private T CreateNewObject()
        {
            var newObject = GameObject.Instantiate(_prefab);
            _objects.Add(newObject);
            return newObject;
        }

    }
}