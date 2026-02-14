using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int hp =1;
    public UnityEvent OnDeath;

    private bool isDead = false;

    public void TakeDamage(int damage)
    {
        //ダメージを受けたかを確認する
        if(isDead) return;
        hp -= damage;
        if(hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if(isDead) return;
        // 死亡処理自滅スクリプトからも呼ぶ
        isDead = true;
        Debug.Log("スクリプトから死亡処理が呼び出されました");

        OnDeath.Invoke();
        isDead = false;// 死亡処理が完了した後にisDeadをfalseに戻す
        hp =1;// 死亡処理が完了した後にhpを初期値に戻す
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
