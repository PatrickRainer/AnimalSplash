using UnityEngine;

public class AnimalBehaviour : MonoBehaviour
{
    // Animal Speed
    public float speed;
    // Should I stop?
    private bool stop = false;
    // Am I clicked before reaching the finishCollider
    public bool hasClicked = false;
    // The own Animator
    Animator anim;
    // The own AudioSource
    AudioSource audioSource;

    private void Start()
    {
        // Get Animator to member
        anim = GetComponent<Animator>();
        // Get the Audiosource
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!stop)
        {
            Vector3 vel = new Vector3();
            // Direction Vector to bottom
            vel = Vector3.right * speed * Time.deltaTime;

            //Move me
            transform.Translate(vel);
        }
    }

    /// <summary>
    /// Stopps the Animal
    /// </summary>
    void StopMoving()
    {
        stop = true;
    }

    void OnClicked()
    {
        // If I am not already clicked
        if (!hasClicked)
        {
            // Play the AudioClip at my Position
            audioSource.Play();

            // Speed up
            this.speed = 10;

            // Save my Position temporary
            Vector3 pos = transform.position;

            // Push my position backwards
            pos.z = 5;

            // Set new Postion, so that other objects lay over this
            transform.position = pos;

            // hasClicked to true
            hasClicked = true;

        }
    }

    public void DestroyMe()
    {
        Destroy(this.gameObject, 1);
    }
}
