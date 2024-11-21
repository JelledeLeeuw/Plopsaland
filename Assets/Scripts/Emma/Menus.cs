using UnityEngine;

public class Menus : MonoBehaviour
{
    private bool paused;
    [SerializeField] private GameObject pauseMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                Debug.Log("Pause");
                Time.timeScale = 0;
                paused = true;
                pauseMenu.SetActive(true);
            }
            else if (paused)
            {
                Debug.Log("Unpause");
                Time.timeScale = 1;
                paused = false;
                pauseMenu.SetActive(false);
            }
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Continue()
    {
        paused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
}
