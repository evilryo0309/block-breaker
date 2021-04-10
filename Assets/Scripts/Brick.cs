using UnityEngine;

public class Brick : MonoBehaviour
{
    public Sprite[] hitSprites;
    public AudioClip crack;
    public GameObject smoke;

    int timesHits;

    LevelManager levelManager;

    bool isBreakable;

    public static int breakableCount = 0;

    private void Start()
    {
        isBreakable = (tag == "Breakable");
        if (isBreakable)
            breakableCount++;

        timesHits = 0;
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position);
        if(isBreakable)
            HandleHit();
    }

    private void HandleHit()
    {
        timesHits++;
        int maxHits = hitSprites.Length + 1;
        if (timesHits >= maxHits)
        {
            breakableCount--;
            levelManager.BrickDestroyed();
            PuffSmoke();
            Destroy(gameObject);
        }
        else
            LoadSprite();
    }

    private void PuffSmoke()
    {
        GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity);
        var mainModule = smokePuff.GetComponent<ParticleSystem>().main;
        mainModule.startColor = GetComponent<SpriteRenderer>().color;
        Destroy(smokePuff, mainModule.duration);
    }

    private void LoadSprite()
    {
        int spriteIndex = timesHits - 1;
        if (hitSprites[spriteIndex] != null)
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        else
            Debug.LogError("Brick sprite missing");
    }

    private void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }
}
