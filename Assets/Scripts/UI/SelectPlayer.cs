using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class SelectPlayer : MonoBehaviour, IPointerClickHandler
    {
        public string PlayerType;

        public bool IsSelected;

        public GameObject SelectMark;


        public void SetSelected(bool isSelected)
        {
            IsSelected = isSelected;
            SelectMark.SetActive(isSelected);
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            if (!IsSelected)
                SocketController.RequestSelectCharacter(new PickData(SocketController.SocketId, PlayerType));
        }
    }
}