using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
    public void ResetLevel()
    {
        SceneManager.LoadScene("Level01");
    }
}