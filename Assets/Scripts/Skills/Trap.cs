using UnityEngine;

namespace Skills
{
    public class Trap : MonoBehaviour
    {
        public float timeLeft = 0.3f;
        private void OnCollisionEnter2D(Collision2D other)
        {
            GameObject otherGo = other.gameObject;
            if (otherGo.name == "Boss")
            {
                otherGo.GetComponent<Boss>().stunTime = 5.0f;
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