using UnityEngine;

[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(MovementController))]
public class HealthController : MonoBehaviour
{
    [SerializeField] private int health;

    private float timeAnimDeath = 1;
    private float force = 50f;

    private int layer = 6;

    private MovementController movementController;
    public MovementController MovementController { get { if (movementController == null)
                movementController = GetComponent<MovementController>(); return movementController; } }

    private InputManager inputManager;
    public InputManager InputManager { get { if(inputManager == null) 
                inputManager = GetComponent<InputManager>(); return inputManager; } }

    public bool PlayerIsAlive { get; set; }

    public void Hurt(int damage)
    {
        if (PlayerIsAlive)
        {
            health = health - damage;

            AnimHitPlayer();

            if (health <= 0)
            {
                Death();
            }

            PlayerIsAlive = false;
        }
    }

    public void Death()
    {
        Destroy(gameObject, timeAnimDeath);

        SetDeathBehavoir();
    }

    private void SetDeathBehavoir()
    {
        MovementController.Body2D.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        MovementController.SpriteRenderer.sortingOrder = layer;
        MovementController.BoxCol2D.enabled = false;
        InputManager.enabled = false;
    }

    public void AnimHitPlayer()
    {
        MovementController.Animator.SetTrigger("isHit");
    }
}
