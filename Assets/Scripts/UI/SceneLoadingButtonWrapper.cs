using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class SceneLoadingButtonWrapper : MonoBehaviour
    {
        [SerializeField] private bool loadsSecondaryScene;
        [SerializeField] private string sceneToLoadName;
        [SerializeField] private string secondarySceneToLoadName;

        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(LoadScenes);
        }

        private void LoadScenes()
        {
            SceneManager.LoadScene(sceneToLoadName);
            
            if (loadsSecondaryScene && !string.IsNullOrEmpty(secondarySceneToLoadName))
            {
                SceneManager.LoadScene(secondarySceneToLoadName, LoadSceneMode.Additive);
            }
        }
    }
}