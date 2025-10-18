using UnityEngine;

public class Spawns : MonoBehaviour
{
    [SerializeField] GameObject inimigoPrefab;
    [SerializeField] GameObject SpawnPoint;

    [SerializeField] GameObject[] PrimeiraWave;
    [SerializeField] Transform[] SpawnsPrimeiraWave;

    [SerializeField] GameObject[] SegundaWave;
    [SerializeField] Transform[] SpawnsSegundaWave;

    

    Vector3 SpawnPosition;

    float SpawnTimer = 0;
    float SpawnInterval = 5;

    bool PodeSpawnar = true;
    int inimigosVivos = 0;

    bool segundaWaveIniciada = false;

    void Start()
    {
       Invoke("SpawnPrimeiraWave", 14f);
      // Invoke("SpawnSegundaWave", 24f);
    }

    void Update()
    {
        TimerdosInimigos();

        
    }

    public void SpawnPrimeiraWave()
    {
        PodeSpawnar = false;

        inimigosVivos = PrimeiraWave.Length;

        for (int i = 0; i < PrimeiraWave.Length; i++)
        {
            
          Vector3 posicao = SpawnsPrimeiraWave[i % SpawnsPrimeiraWave.Length].position;

       GameObject inimigoObj =  Instantiate(PrimeiraWave[i], posicao, Quaternion.identity);

        Inimigo inimigoScript = inimigoObj.GetComponent<Inimigo>();

        if (inimigoScript != null)
        {
            inimigoScript.SpawnsManager = this;
        }

        }

        
    }

    public void SpawnSegundaWave()
    {
        PodeSpawnar = false;

        inimigosVivos = SegundaWave.Length;

        for (int i = 0; i < SegundaWave.Length; i++)
        {
             Vector3 posicao = SpawnsSegundaWave[i % SpawnsSegundaWave.Length].position;
            GameObject inimigoObj = Instantiate (SegundaWave[i], posicao, Quaternion.identity);

            Inimigo inimigoScript = inimigoObj.GetComponent<Inimigo>();

            if (inimigoScript != null)
            {
                inimigoScript.SpawnsManager = this;
            }
        }
        
    }

   
    

    void TimerdosInimigos()
    {
        if (!PodeSpawnar) return;

        SpawnTimer += Time.deltaTime;
        if (SpawnTimer > SpawnInterval)
        {
            SpawnPosition = new Vector3(SpawnPoint.transform.position.x, SpawnPoint.transform.position.y, Random.Range(-12, 5));

           
            GameObject InimigoInstanciado = Instantiate(inimigoPrefab, SpawnPosition, SpawnPoint.transform.rotation);
           
            
            SpawnTimer = 0;
        }
    }

    public void InimigoMorreu()
    {
        inimigosVivos --;

        if (inimigosVivos <= 0)
        {
            Debug.Log("todos os inimigs morreram");
            PodeSpawnar = true;

            if (!segundaWaveIniciada)
        {
            segundaWaveIniciada = true;
            Invoke("SpawnSegundaWave",10);
        }
        }
    }

}
