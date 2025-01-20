using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Project._Screpts.Load
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private TextMeshProUGUI _textProgress;

        public void Start() => LoadNextScene();

        private async void LoadNextScene()
        {
            var nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            var taskLoad = SceneManager.LoadSceneAsync(nextSceneIndex);
            taskLoad.allowSceneActivation = false;
            while (taskLoad.progress < 0.9f)
            {
                int progressPercentage = Mathf.RoundToInt(taskLoad.progress * 100);
                _textProgress.text = $"{progressPercentage}%";
                _slider.value = taskLoad.progress;
                await UniTask.Yield();
            }

            _slider.value = 1f;
            _textProgress.text = "100%";
            taskLoad.allowSceneActivation = true;
        }
    }
}