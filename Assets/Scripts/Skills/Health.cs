using UnityEngine;

namespace Skills
{
    public class Health : bullet
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject != Shooter)
            {
                OnlineCharacter character = other.gameObject.GetComponent<OnlineCharacter>();
                if (character != null && character.Character != "Boss")
                {
                    SocketController.RequstPlayerHealthChanged(new ChangeHealthData(character.SocketId, -20));
                    Destroy(gameObject);
                }
            }
        }
    }
}