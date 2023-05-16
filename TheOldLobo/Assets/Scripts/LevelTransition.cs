using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    // Start is called before the first frame update
    public int sceneBuildIndex;

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("trigger entered");
        if (other.gameObject.name == "Player")
        {
            print("Level transition" + sceneBuildIndex);
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}