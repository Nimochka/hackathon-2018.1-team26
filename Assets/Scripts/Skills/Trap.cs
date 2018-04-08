using UnityEngine;

namespace Skills
{
    public class Trap : MonoBehaviour
    {
        public float timeLeft = 0.3f;
        private void OnTriggerEnter2D(Collider2D other)
        {
            GameObject otherGo = other.gameObject;
            if (otherGo.tag == "Boss")
            {
                SocketController.RequestBossTrap(new TrapData(otherGo.GetComponent<OnlineCharacter>().SocketId));
                GameObject.Destroy(gameObject);
            }
        }

        private void Update()
        {
            if (timeLeft <= 0)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
            else
            {
                timeLeft -= Time.deltaTime;
            }
        }
    }
}