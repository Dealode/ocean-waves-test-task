using System.Collections;
using UnityEngine;

namespace Code.Services.Coroutines
{
    public interface ICoroutineRunner
    {
        public Coroutine StartCoroutine(IEnumerator routine);
    }
}