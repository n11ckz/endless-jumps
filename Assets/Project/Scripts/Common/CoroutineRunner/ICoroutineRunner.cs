using System.Collections;
using UnityEngine;

namespace Project
{
    public interface ICoroutineRunner
    {
        public Coroutine StartCoroutine(IEnumerator routine);
    }
}
