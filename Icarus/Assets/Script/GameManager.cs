using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine.SceneManagement; // necessário para sceneLoaded

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

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // Atualiza SpawnPoint ao carregar cena
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        EncontrarSpawnPoint();
    }

    private void Awake()
    {
        if (Mestre == null)
        {
            Mestre = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Tenta pegar SpawnPoint da cena inicial (caso exista)
        EncontrarSpawnPoint();
    }

    void EncontrarSpawnPoint()
    {
        if (SpawnPoint == null)
        {
            SpawnPoint = GameObject.FindWithTag("SpawnPoint");

            if (SpawnPoint != null)
            {
                DontDestroyOnLoad(SpawnPoint);
            }
        }
    }

    private void Start()
    {
        InvokeRepeating("SpawnPrimeiraWave", 1f, 8f); //invoca as waves repetidamente
        Pontos = 0;
    }

    void Update()
    {
        Zawarudo();
        TimerdosInimigos();
        if (Input.GetKeyDown(KeyCode.B)) // mostra seus pontos
        {
            Debug.Log($"Seus pontos sao: {Pontos}");
        }

        if (Player.PlayerVivo == false)
        {
            CancelInvoke();
        }
    }

    void Zawarudo() //pausa o tempo
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = tempo;
        }
    }

    public void AlterarPontos(int pontos)
    {
        Pontos += pontos;
    }

    public void SpawnPrimeiraWave()
    {
        EncontrarSpawnPoint(); // garante que o SpawnPoint está definido

        if (SpawnPoint == null)
        {
            Debug.LogWarning("SpawnPoint não definido. Não é possível spawnar a wave.");
            return;
        }

        for (int i = 0; i < PrimeiraWave.Length; i++)
        {
            Vector3 pos = new Vector3(
                SpawnPoint.transform.position.x,
                SpawnPoint.transform.position.y,
                Random.Range(-12, 5)
            );

            Instantiate(PrimeiraWave[i], pos, SpawnPoint.transform.rotation);
        }
    }

    void TimerdosInimigos()
    {
        EncontrarSpawnPoint(); // garante que o SpawnPoint está definido

        if (SpawnPoint == null) return;

        SpawnTimer += Time.deltaTime;
        if (SpawnTimer > SpawnInterval)
        {
            SpawnPosition = new Vector3(
                SpawnPoint.transform.position.x,
                SpawnPoint.transform.position.y,
                Random.Range(-12, 5)
            );

            Instantiate(inimigoPrefab, SpawnPosition, SpawnPoint.transform.rotation);

            SpawnTimer = 0;
        }
    }
}
