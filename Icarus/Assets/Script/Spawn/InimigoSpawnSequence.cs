using UnityEngine;
using System.Collections;




public class InimigoSpawnSequence : MonoBehaviour
{
    

     [System.Serializable]
    public class EnemySpawnData
    {
        public GameObject enemyPrefab;   // Prefab do inimigo
        public Vector3 position;         // Posição onde vai nascer
        public float delay;              // Tempo de espera antes do próximo inimigo
    }

    [System.Serializable]
    public class WaveData
    {
        public string waveName = "Nova Wave";
        public EnemySpawnData[] enemies;   // Lista de inimigos dessa wave
        public float delayAfterWave = 5f;  // Espera antes da próxima wave
    }


    [Header("Sequência de spawn")]
    public EnemySpawnData[] spawnList;

    [Header("Referência ao GameManager (opcional)")]
    public GameManager gameManager;

    void Start()
    {
        if (gameManager == null)
            gameManager = GameManager.Mestre;

        StartCoroutine(SpawnSequenceRoutine());
    }

    IEnumerator SpawnSequenceRoutine()
    {
        foreach (var spawn in spawnList)
        {
            yield return new WaitForSeconds(spawn.delay);

            if (spawn.enemyPrefab != null)
            {
                Instantiate(
                    spawn.enemyPrefab,
                    spawn.position,
                    Quaternion.identity
                );
            }
        }
    }
}
