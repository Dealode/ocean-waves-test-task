using System;
using System.Collections;
using Code.Services.Coroutines;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Code.Infrastructure.Loading
{
    public class SceneLoader : ISceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;
        public SceneLoader(ICoroutineRunner coroutineRunner) => 
            _coroutineRunner = coroutineRunner;

        public void LoadScene(string name, LifetimeScope parent, Action onLoaded = null) =>
            _coroutineRunner.StartCoroutine(Load(name, parent, onLoaded));

        private IEnumerator Load(string nextScene, LifetimeScope parent, Action onLoaded)
        {
            if (SceneManager.GetActiveScene().name == nextScene)
            {
                onLoaded?.Invoke();
                yield break;
            }
            
            using (LifetimeScope.EnqueueParent(parent))
            {
                AsyncOperationHandle<SceneInstance> waitNextScene = Addressables.LoadSceneAsync(nextScene);

                while (!waitNextScene.IsDone || waitNextScene.Status != AsyncOperationStatus.Failed)
                    yield return null;

                onLoaded?.Invoke();
            }
        }
    }
}