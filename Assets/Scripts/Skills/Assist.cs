using UnityEngine;

namespace Skills
{
    public class Assist:MonoBehaviour
    {
        public float lifeTime = 5.0f;
        public bool bossDetected = false;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Boss")
            {
                bossDetected = true;
            }
        }


        private void Update()
        {
            if (bossDetected)
            {
                if (lifeTime <= 0)
                {
                    bossDetected = false;
                    GameObject.Destroy(gameObject);
                }
                else
                {
                    GameObject tank = GameObject.FindGameObjectWithTag("Tank");
                    GameObject boss = GameObject.FindGameObjectWithTag("Boss");
                    Vector3 direct = tank.transform.position - boss.transform.position;
//                    direct.Normalize();
                    GameObject.FindGameObjectWithTag("Boss").gameObject.transform.up = direct;
                    lifeTime -= Time.deltaTime;
                }
            }
        }
    }
}