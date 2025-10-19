using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManger : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("Jogo");
    }

    private void Update()
    {
        Ganhar();
    }

    void Ganhar() //Ganha se Fizer 1000 pontos
    {
        if (GameManager.Mestre == null) return;
        if (GameManager.Mestre.Pontos >= 10000)
        {
            SceneManager.LoadScene("Victory");
        }

    }
}
