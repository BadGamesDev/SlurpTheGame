using UnityEngine;

public class ProjectileGenerator : MonoBehaviour
{
    public GameObject projectilePrefab;
    
    public float remainingCoolDown;
    public float coolDown;

    private void FixedUpdate()
    {
        GenerateProjectiles();
    }

    public void GenerateProjectiles()
    {
        remainingCoolDown -= Time.fixedDeltaTime;
        
        if (remainingCoolDown <= 0)
        {
            remainingCoolDown = coolDown;
            int x = 0;
            
            while (x < 240)
            {
                Vector2 position;
                
                if (x % 2 == 0)
                {
                    position = new Vector2(20, x + 20);
                }

                else
                {
                    position = new Vector2(-20, x + 20);
                }

                GameObject newProjectile = Instantiate(projectilePrefab, position, Quaternion.identity);
                ProjectileMovement movementScript = newProjectile.GetComponent<ProjectileMovement>();
                movementScript.delay = Random.Range(0, coolDown);
                movementScript.speed = (1 + position.y / 20) / 10;
                
                x += 1;
            }
        }
    }
}
