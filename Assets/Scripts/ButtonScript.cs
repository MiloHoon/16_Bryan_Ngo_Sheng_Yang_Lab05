using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene("GameScene");
    }
}
