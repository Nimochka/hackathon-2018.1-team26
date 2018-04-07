using UnityEngine;

namespace Skills
{
    public class Health : bullet
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            Character character = other.gameObject.GetComponent<Character>();
            if (character != null && (character is Tank || character is Hunter))
                character.HealthPoints += 1;
        }
    }
}