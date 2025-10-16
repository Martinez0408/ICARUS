using Unity.VisualScripting;
using UnityEngine;



public class GameManager : MonoBehaviour
{
  [SerializeField] float tempo = 0.25f;
    void Update()
    {
        Zawarudo();
    }


    void Zawarudo()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = tempo;
        }

    }
}
