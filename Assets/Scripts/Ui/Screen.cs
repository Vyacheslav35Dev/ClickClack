using UnityEngine;

namespace Ui
{
    public class Screen : MonoBehaviour
    {
        public ScreenType Type;
        public void Show(bool state)
        {
            this.gameObject.SetActive(state);
        }
    }
}