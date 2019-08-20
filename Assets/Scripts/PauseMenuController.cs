using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    private Button btnResume;

    private void Awake()
    {
        btnResume = GameObject.Find("BtnResume").GetComponent<Button>();
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
