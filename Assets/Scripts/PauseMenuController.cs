using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    private Button btnResume;
    private LevelController myLevelController;
    private EventManager myEventManager;

    private void Awake()
    {
        btnResume = GameObject.Find("BtnResume").GetComponent<Button>();
        myEventManager = GameObject.FindObjectOfType<EventManager>();
        myLevelController = GameObject.Find("LevelManager").GetComponent<LevelController>();
        myEventManager.OnLevelPlays.AddListener(HidePauseMenu);
    }

    private void HidePauseMenu()
    {
        this.gameObject.SetActive(false);
    }

    private void Start()
    {
       this.gameObject.SetActive(false);
    }
    public void ShowPauseMenu(bool SetResumeBtnActive)
    {
        this.gameObject.SetActive(true);

        if (!SetResumeBtnActive)
        {
            btnResume.interactable = false;
        }
    }


}
