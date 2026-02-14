using UnityEngine;


public class DeathEffect : MonoBehaviour
{
    [SerializeField] private GameObject deathEffectPrefab; // 死亡エフェクトのプレハブ
    [SerializeField] private AudioClip deathSE; // 死亡時のサウンドエフェクト
    [SerializeField] private float volume = 3.0f;
    [SerializeField] private float blinkInterval = 0.1f; // 点滅の間隔
    [SerializeField] private float blinkDuration = 1.0f; // 点滅する合計時間

    private SpriteRenderer spriteRenderer;
    private double _time;

    private void Awake()
    {
         spriteRenderer = GetComponent<SpriteRenderer>();
 
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void PlayEffect()
    {
        if (deathEffectPrefab != null)
        {
            Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
        }

        if (deathSE != null)
        {
            AudioSource.PlayClipAtPoint(deathSE, transform.position, volume);
        }

        if (spriteRenderer != null)
        {
            StartCoroutine(BlinkEffect());
        }
    }

    private System.Collections.IEnumerator BlinkEffect()
    {
        float elapsedTime = 0f;
        while (elapsedTime < blinkDuration)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled; // 点滅
            yield return new WaitForSeconds(blinkInterval);
            elapsedTime += blinkInterval;
        }
        spriteRenderer.enabled = true; // 最後に表示状態に戻す

    }

}
