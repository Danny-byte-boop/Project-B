using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
public class PlayerAttack : MonoBehaviour
{
    public int attackDamage = 50;
    public Transform attackPoint;

    public float attackRange = 0.25f;
    public LayerMask enemyLayers;

    public SpriteRenderer swordSprite;
    public float swingDuration = 0.5f;

    public SwordVisibility swordVisibility;
    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.xKey.wasPressedThisFrame || Mouse.current.rightButton.wasPressedThisFrame)
        {
            Attack();
        }
    }
    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitSlugs = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitSlugs) 
        {
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null) 
            {
                enemyHealth.TakeDamage(attackDamage);
            }
        }
        StartCoroutine(SwingEffect());
    }

    IEnumerator SwingEffect()
    {
        swordVisibility.ShowSword();
        Color originalColor = swordSprite.color;
        swordSprite.color = Color.white;
        yield return new WaitForSeconds(swingDuration);

        swordSprite.color = originalColor;
        swordVisibility.HideSword();
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
   

}

