using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    LevelManager levelManager;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        levelManager.LoadLevel("Lose Screen");
    }
}
