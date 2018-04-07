using UnityEngine;

namespace Skills
{
    public class Dash : MonoBehaviour
    {

        private float lifeTime = 0.3f;

        private void Start()
        {
            GameObject boss = GameObject.FindGameObjectWithTag("Boss");
            boss.GetComponent<Boss>().destroyMode = true;
            Vector2 newVector = new Vector2(boss.transform.up.x * 1000, boss.transform.up.y * 1000);
            newVector.Normalize();
            newVector *= 7000;
            boss.GetComponent<Character>().OnlinePlayer = true;
            boss.GetComponent<Rigidbody2D>().velocity = newVector;
        }

        private void Update()
        {
            if (lifeTime <= 0)
            {
                GameObject boss = GameObject.FindGameObjectWithTag("Boss");
                boss.GetComponent<Character>().OnlinePlayer = false;
                boss.GetComponent<Boss>().destroyMode = false;
                GameObject.Destroy(gameObject);
            }
            else
            {
                lifeTime -= Time.deltaTime;
            }
            
        }
    }
}