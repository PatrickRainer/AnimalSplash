using UnityEngine;

public class Moving : MonoBehaviour
{
    
    [Tooltip("Defines the speed of the ghosts")]
    public float speed;

    // Should I stop?
    bool stop = false;

    private void Update()
    {
        if (!stop)
        {
            Vector3 vel = new Vector3();
            // Direction Vector to bottom
            vel = Vector3.down * speed * Time.deltaTime;

            //Move me
            transform.Translate(vel);
        }
    }

    /// <summary>
    /// Stopps the ghost
    /// </summary>
    void StopMoving()
    {
        stop = true;
    }

}
