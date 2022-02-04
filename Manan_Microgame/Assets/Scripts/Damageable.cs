/* 
This class deals with the functionality of the targets in the game. While max health and current health is obsolete currently,
It has been left in the code as the health of targets can be updated without any large effect on the game.

The Start function initializes the value of currentHealth of the target to the maxHealth.

The TakeDamage function deals with how the targets take damage. This is invoked by the Gun function when the hitscan ray hits the 
target. It also checks if the health of the target is less than or equal to 0, to make sure it dies (dissapears) when the condition
is met

The Die function makes sure that the target disappears when its health is depleted it is invoked by TakeDamage.
*/

using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] AudioSource hitEffect;
    [SerializeField] float maxHealth = 10f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        hitEffect.Play();
        Destroy(gameObject);
    }
}
