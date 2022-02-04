/* 
This class is used to control the action of the gun and to keep track of the number
of targets in the game.

The Awake function assigns the cam transform to the main camera of the game on awake.

The Shoot function deals with the mechains of shooting. When left click is pressed, a ray is drawn from the center of the camera.
If the ray touches a damagable object it updates the number of hits, number of shots and the number of targets present. 
It also plays the shoot SFX.

The Start function initializes the values of currentTargetCount, hitCount and shootCount when the scene starts. currentTargetCount
is assigned to the max number of targets which is targetCount.
*/

using UnityEngine;

public class Gun : MonoBehaviour
{
    Transform cam;
    [SerializeField] float range = 50f;
    [SerializeField] float damage = 10f;
    [SerializeField] AudioSource shootEffect;
    public float shootCount;
    public float hitCount;
    public int targetCount = 16;
    public int currentTargetCount;

    private void Awake()
    {
        cam = Camera.main.transform; 
    }

    public void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.position, cam.forward, out hit, range))
        {
            if(hit.collider.GetComponent<Damageable>() != null)
            {
                hit.collider.GetComponent<Damageable>().TakeDamage(damage);
                hitCount++;
                currentTargetCount--;
            }
        }
        shootEffect.Play();
        shootCount++;
    }
    
    void Start()
    {
        currentTargetCount = targetCount;
        hitCount = 0;
        shootCount = 0;
    }
}
