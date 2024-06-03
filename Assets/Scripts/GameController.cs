using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private Transform player;
    private HealthController healthController;

    [SerializeField] private Transform prefab;

    private float lineDeath = -13f;

    private int damage = 1;

    private void Start()
    {
        CreatePrefab();

        if(player != null)
        {
            if(this.player.TryGetComponent<HealthController>(out var player))
            {
                healthController = player;

                healthController.PlayerIsAlive = true;
            }
        }
    }

    private void Update()
    {
        //if (player == null)
        //{
        //    CreatePrefab();
        //    if (player.TryGetComponent<HealthController>(out var healthControl))
        //    {
        //        healthController = healthControl;
        //    }
        //    healthController.PlayerIsAlive = true;
        //}

        //if (healthController.PlayerIsAlive)
        //{
        //    if (healthController.transform.position.y < lineDeath)
        //    {
        //        healthController.Hurt(damage);
        //        healthController.PlayerIsAlive = false;
        //    }
        //}

        if (player != null)
        {
            if (healthController.PlayerIsAlive)
            {
                if (player.transform.position.y < lineDeath)
                {
                    healthController.AnimHitPlayer();

                    healthController.Death();

                    healthController.PlayerIsAlive = false;
                }
            }
        }
        else
        {
            print("SceneManager");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void CreatePrefab()
    {
        var rotation = Quaternion.identity;
        var position = new Vector2(0.0f, 0.0f);

        if(prefab != null)
        {
            player = Instantiate(prefab, position, rotation);
        }
        else
        {
            Debug.LogError("Prefab is null!");
        }
    }
}
