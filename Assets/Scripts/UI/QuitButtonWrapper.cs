using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class QuitButtonWrapper : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(Application.Quit);
        }
    }
}