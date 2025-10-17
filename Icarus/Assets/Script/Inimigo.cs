using UnityEngine;

public class Inimigo : MonoBehaviour
{
    
    [SerializeField] GameObject EnemyShot;
    [SerializeField] GameObject SpawnEnemy;
    [SerializeField] float ShotFrequency = 10f;
    float FireTimer = 0;



    void Start()
    {
        InvokeRepeating("Atirar", ShotFrequency, ShotFrequency);
    }

    void Atirar()
    {
        GameObject tiro = Instantiate(EnemyShot, SpawnEnemy.transform.position, SpawnEnemy.transform.rotation);
    }

    void Destruir() //apaga o inimigo da cena
    {
    Destroy(gameObject);
    }
   public void Morrer() // Desativa e depois de um tempo deleta o inimigo
    {
        CancelInvoke();
        gameObject.SetActive(false);
        Invoke("Destruir", 6f);
    }
}
