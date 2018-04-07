using UnityEngine;

namespace Skills
{
    public class PoisonArrow:bullet
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            GameObject otherGo = other.gameObject;
            if (otherGo.name == "Boss")
            {
                Debug.Log(otherGo.GetComponent<Boss>().HealthPoints);
            }
        }
    }
}