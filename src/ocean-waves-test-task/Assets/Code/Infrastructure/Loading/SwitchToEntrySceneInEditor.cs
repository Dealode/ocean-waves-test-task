using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Infrastructure.Loading
{
    public class SwitchToEntrySceneInEditor : MonoBehaviour
    {
#if UNITY_EDITOR
        private const int EntrySceneIndex = 0;

        private void Awake()
        {
            GameBootstrapper bootstrapper = FindAnyObjectByType<GameBootstrapper>();

            if (bootstrapper != null)
                return;
            
            foreach (GameObject root in gameObject.scene.GetRootGameObjects()) 
                root.SetActive(false);
      
            SceneManager.LoadScene(EntrySceneIndex);
        }
#endif
    }
}
