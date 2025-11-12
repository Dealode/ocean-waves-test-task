using System;
using VContainer.Unity;

namespace Code.Infrastructure.Loading
{
    public interface ISceneLoader
    {
        void LoadScene(string name, LifetimeScope parent, Action onLoaded = null);
    }
}