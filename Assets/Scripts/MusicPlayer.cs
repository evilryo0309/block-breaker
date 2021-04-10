using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    static MusicPlayer instance = null;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Duplicate Music Player, self-destruct.");
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
