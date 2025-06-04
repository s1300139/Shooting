using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) // 敵のタグと一致するか
        {
            Destroy(other.gameObject); // 敵を消す
            Destroy(gameObject);       // 弾も消す
        }
    }
}
