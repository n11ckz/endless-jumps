using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Project
{
    public class SceneLoader : IInitializable
    {
        private const int GameplaySceneIndex = 1;

        private readonly Curtain _curtain;
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(Curtain curtain, ICoroutineRunner coroutineRunner)
        {
            _curtain = curtain;
            _coroutineRunner = coroutineRunner;
        }

        public void Initialize() => LoadGameplayScene();

        public void LoadGameplayScene() => _coroutineRunner.StartCoroutine(LoadSceneAsync(GameplaySceneIndex));

        private IEnumerator LoadSceneAsync(int sceneIndex)
        {
            AsyncOperation sceneAsyncOperation = SceneManager.LoadSceneAsync(sceneIndex);

            while (!sceneAsyncOperation.isDone)
                yield return null;

            _curtain.HideWithDelay();

            Debug.Log("Scene is loaded");
        }
    }
}
