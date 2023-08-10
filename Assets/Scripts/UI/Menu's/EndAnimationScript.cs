using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class EndAnimationScript : MonoBehaviour
{
    [SerializeField] private float duration;

    private void Update()
    {
        duration -= Time.deltaTime;
        if (duration <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
