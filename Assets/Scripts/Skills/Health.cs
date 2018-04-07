using UnityEngine;

namespace Skills
{
    public class Health:bullet
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            GameObject otherGo = other.gameObject;
            if (otherGo.name == "Hunter" || otherGo.name == "Tank")
            {
                otherGo.GetComponent<Character>().HealthPoints += 1;
                Debug.Log(otherGo.GetComponent<Character>().HealthPoints);
            }
        }
    }
}