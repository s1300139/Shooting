using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float lifeTime = 5f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {

            // 敵を消す
            Destroy(gameObject);
        }
    }
}

