using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class SelectPlayer : MonoBehaviour, IPointerClickHandler
    {
        public string PlayerType;

        public bool IsSelected;

        public GameObject SelectMark;


        public void SetSelected(string socketId)
        {
            bool isSelected = socketId != "";
            IsSelected = isSelected;
            SelectMark.SetActive(isSelected);

            if (SocketController.SocketId == socketId)
                SocketController.Character = PlayerType;
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            if (!IsSelected)
                SocketController.RequestSelectCharacter(new PickData(SocketController.SocketId, PlayerType));
        }
    }
}