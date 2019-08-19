using UnityEngine;

public class AnimalBehaviour : MonoBehaviour
{
    // Animal Speed
    public float speed;
    // Should I stop?
    private bool stop = false;
    // Am I clicked before reaching the finishCollider
    private bool _isClicked = false;
    public bool isClicked { get { return _isClicked; } set { _isClicked = value; AnimalOnClicked(); } }
    // The own Animator
    Animator anim;
    // The own AudioSource
    AudioSource audioSource;

    public delegate void AnimalClicked();
    public event AnimalClicked AnimalOnClicked;

    private void Start()
    {
        // Get Animator to member
        anim = GetComponent<Animator>();
        // Get the Audiosource
        audioSource = GetComponent<AudioSource>();
        // Assign the OnClicked event
        AnimalOnClicked += AnimalBehaviour_AnimalOnClicked;
    }

    public void SetIsClicked()
    {
        isClicked = true;
    }
    private void AnimalBehaviour_AnimalOnClicked()
    {
        // If I am not already clicked
        if (!_isClicked)
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
            isClicked = true;
        }
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

    public void DestroyMe()
    {
        Destroy(this.gameObject, 1);
    }
}
