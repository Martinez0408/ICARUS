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

    [SerializeField] GameObject inimigoPrefab;
    [SerializeField] GameObject SpawnPoint;
    [SerializeField] GameObject[] PrimeiraWave;
   
    Vector3 SpawnPosition;

    float SpawnTimer = 0;
    float SpawnInterval = 5;

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
       Invoke("SpawnPrimeiraWave", 1f);

        Pontos = 0;
    }

   
    void Update()
    {
        Zawarudo();
        TimerdosInimigos();
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

    
   

    public void SpawnPrimeiraWave()
    {
        for (int i = 0; i < PrimeiraWave.Length; i++)
        {
            Instantiate(PrimeiraWave[i], new Vector3(SpawnPoint.transform.position.x, SpawnPoint.transform.position.y, Random.Range(-12, 5)), SpawnPoint.transform.rotation);
        }
    }


    void TimerdosInimigos()
    {


        SpawnTimer += Time.deltaTime;
        if (SpawnTimer > SpawnInterval)
        {
            SpawnPosition = new Vector3(SpawnPoint.transform.position.x, SpawnPoint.transform.position.y, Random.Range(-12, 5));

           
            GameObject meuInimigiInstanciado = Instantiate(inimigoPrefab, SpawnPosition, SpawnPoint.transform.rotation);
           
            
            SpawnTimer = 0;
        }
    }

    

}







  


   

    

