using UnityEngine;

public class AttributeController : MonoBehaviour
{
    public const int MaxHealth = 10; 
    
    public int health;
    public int hitDamage;

    public GameObject droppedItem;
    public Canvas gameOverScreen;
    
    
    private Animator animator;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void CardPicked(int health, int damage)
    {
        this.health = health;
        hitDamage = damage;
    }

    public void HealthPickedUp(int amount)
    {
        health += amount;

        if (health > MaxHealth)
            health = MaxHealth;
    }
    
    /// <summary>
    /// Deals damage to this instance
    /// </summary>
    /// <param name="damage">The damage dealt</param>
    /// <returns>True if the Object died</returns>
    public bool OnHit(int damage)
    {
        health -= damage;
        animator.SetBool("IsHit", true);
        return IsDead();
    }

    public void TriggerDeath(bool isPlayerDeath)
    {
        if (!isPlayerDeath)
        {
            if(droppedItem != null)
                Instantiate(droppedItem, transform.position, Quaternion.identity);
            animator.SetBool("IsAlive", false);
        }
        else
        {
            Instantiate(gameOverScreen);
        }
            
    }

    public void Remove()
    {
        Destroy(gameObject);
    }

    public void ResetHurtAnimation()
    {
        animator.SetBool("IsHit", false);
    }

    public bool IsDead()
    {
        return 0 >= health;
    }
}
