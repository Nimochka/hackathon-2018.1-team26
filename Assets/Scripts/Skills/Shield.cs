using UnityEngine;

namespace Skills
{
    public class Shield : MonoBehaviour
    {
        private float lifeTime = 5.0f;

        public GameObject Tank;


        private void Update()
        {
            if (lifeTime <= 0)
            {
                Tank tank = Tank.GetComponent<Tank>();
                if (tank != null)
                    tank.mainSkillLock = false;
                GameObject.Destroy(gameObject);
            }
            else
            {
                lifeTime -= Time.deltaTime;
                Vector3 pos = Tank.transform.position;
                Quaternion quaternion = Tank.transform.rotation;
                pos.x += transform.up.x * 20;
                pos.y += transform.up.y * 20;
                transform.position = new Vector3(pos.x, pos.y);
                transform.rotation = new Quaternion(quaternion.x, quaternion.y, quaternion.z, quaternion.w);
            }
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.name == "Bullet(Clone)")
            {
                GameObject.Destroy(other.gameObject);
            }
        }
    }
}