using UnityEngine;

public class BadEnemy : MonoBehaviour
{
    public int penaltyAmount = 50;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            GameManager gm = FindObjectOfType<GameManager>();
            if (gm != null)
            {
                gm.AddScore(-penaltyAmount);  // 減点
            }

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
