using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManger : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("Jogo");
    }    

    // Update is called once per frame
    void Update()
    {
        
    }
}
