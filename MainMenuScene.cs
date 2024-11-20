using UnityEngine;

public class MainMenuScene : MonoBehaviour
{
    public string SongTitle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FindFirstObjectByType<AudioManager>().Play(SongTitle);
    }
}
