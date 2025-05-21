using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            if (!dead)
            {
                GetComponent<PlayerMovement>().enabled = false;
                anim.SetBool("grounded", true); //be grounded before playing dead anim
                anim.SetTrigger("die");
                dead = true;
            }
        }
    }

    public void Respawn()
    {
        ResetHealth();
        anim.ResetTrigger("die");
        anim.Play("Standing");
    }

    public void ResetHealth()
    {
        currentHealth = startingHealth; 
        dead = false;
    }

}
