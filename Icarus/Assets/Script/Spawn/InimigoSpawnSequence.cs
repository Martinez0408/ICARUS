using UnityEngine;

public class InimigoSpawnSequence : MonoBehaviour
{
    
    [Header("Sequência de inimigos")]
    [SerializeField] GameObject[] inimigosNaOrdem;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float intervaloEntreSpawns = 4f;

   // void Start()
   // {
   //     StartCoroutine(SpawnSequencial());
   // }

   // IEnumerator SpawnSequencial()
   // {
   //     foreach (GameObject inimigo in inimigosNaOrdem)
   //     {
   //         Instantiate(inimigo, spawnPoint.position, spawnPoint.rotation);
   //         yield return new WaitForSeconds(intervaloEntreSpawns);
   //     }
   // }
}
