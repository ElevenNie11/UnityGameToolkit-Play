using UnityEngine;

public class Target : MonoBehaviour
{
   public float health = 50f;
   public void TakeDamage(float amount)   //目标受到伤害
    {
        health -= amount;
        if(health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);              //销毁自身（目标）
    }
}
