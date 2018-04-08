using UnityEngine;

namespace Skills
{
    public class PoisonArrow : bullet
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject != Shooter)
            {
                GameObject otherGo = other.gameObject;
                if (!IsOnlineBullet && otherGo.tag == "Boss")
                    SocketController.RequestPlayerPoison(
                        new PoisonData(otherGo.GetComponent<OnlineCharacter>().SocketId));
                Destroy(gameObject);
            }
        }
    }
}