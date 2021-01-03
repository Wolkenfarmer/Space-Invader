using UnityEngine;

public class PauseController : MonoBehaviour
{
    public static bool Paused { get; private set; }

    Canvas canvas;

    void Start()
    {
        canvas = GameObject.Find("PausedBox").GetComponent<Canvas>();

        Pause(false);
    }

    public void Pause(bool pause)
    {
        Paused = pause;
        Time.timeScale = pause ? 0 : 1;
        canvas.enabled = pause;
    }
}
