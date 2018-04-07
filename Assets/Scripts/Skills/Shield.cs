using UnityEngine;

namespace Skills
{
    public class Shield : MonoBehaviour
    {
        private float lifeTime = 5.0f;


        private void Update()
        {
            if (lifeTime <= 0)
            {
                GameObject.FindGameObjectWithTag("Tank").GetComponent<Tank>().mainSkillLock = false;
                GameObject.Destroy(gameObject);
            }
            else
            {
                lifeTime -= Time.deltaTime;
                Vector3 pos = GameObject.FindGameObjectWithTag("Tank").transform.position;
                Quaternion quaternion = GameObject.FindGameObjectWithTag("Tank").transform.rotation;
                pos.x += transform.up.x * 20;
                pos.y += transform.up.y * 20;
                transform.position = new Vector3(pos.x, pos.y);
                transform.rotation = new Quaternion(quaternion.x, quaternion.y, quaternion.z, quaternion.w);
            }
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.name == "Bullet")
            {
                GameObject.Destroy(other.gameObject);
            }
        }
    }
}