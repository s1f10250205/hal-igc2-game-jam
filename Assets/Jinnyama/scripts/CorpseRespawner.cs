using UnityEngine;

public class CorpseRespawner : MonoBehaviour
{

    [SerializeField] private GameObject corpsePrefab; // 死体のプレハブ
    [SerializeField] private Transform spawnPoint; //死体を生成する場所

    public void SpawnCorpseAndReset()
    {
        Instantiate(corpsePrefab, spawnPoint.position, spawnPoint.rotation);

        if(spawnPoint != null)
        {
            transform.position = spawnPoint.position;

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                rb.linearVelocity = Vector2.zero; //死亡時の速度をリセット
                rb.angularVelocity =0f; //死亡時の回転速度をリセット
            }
        }
    }


}
