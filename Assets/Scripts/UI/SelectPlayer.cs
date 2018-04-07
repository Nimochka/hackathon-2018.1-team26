using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace UI
{
    public class SelectPlayer : MonoBehaviour, IPointerClickHandler
    {
        public string PlayerType;
        private Color prevColor;
        
        

        public void OnPointerClick(PointerEventData eventData)
        {
            //TODO отправка на сервер выбора персонажа
            SceneManager.LoadScene("Main");
        }
    }
}