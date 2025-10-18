using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using System.Collections.Generic;
using static UnityEditor.PlayerSettings;
using System.Runtime.InteropServices.WindowsRuntime;




public class GameManager : MonoBehaviour
{
    public static GameManager Mestre; 
    
    [SerializeField] float tempo = 0.25f;

    public int Pontos = 0;

    private void Awake()
    {
        if (Mestre == null)
        {
            Mestre = this;
        }
        else
        { 
        Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    }

    private void Start()
    {
      // Invoke("SpawnPrimeiraWave", 12f);
      // Invoke("SpawnSegundaWave", 22);

        Pontos = 0;
    }

   
    void Update()
    {
        Zawarudo();
     //   TimerdosInimigos();
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log($"Seus pontos são: {Pontos}");
        }
    }


    void Zawarudo()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = tempo;
        }

    }

    public void AlterarPontois(int pontos)
    {
        Pontos += pontos;
    }  

}







  


   

    

