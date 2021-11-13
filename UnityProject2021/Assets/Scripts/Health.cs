using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float health = 100;
    void OnCollisionEnter(Collision collision)
    {

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Needle")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Hit!");
            health = health - 25;

            if(health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}