using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Rendering;

public class Inimigo : MonoBehaviour
{

    [SerializeField] GameObject EnemyShot;
    [SerializeField] GameObject SpawnEnemy;
    [SerializeField] float ShotFrequency = 10f;
    public GameManager GameManager;
    float FireTimer = 1;
    float MoveTimer = 0;

    [SerializeField] float speed;

    private Vector3 moveInput;
    private Rigidbody rb;


    void Start()
    {
        InvokeRepeating("Atirar", FireTimer, ShotFrequency);
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("Move", 0, Time.deltaTime);

    }

    private void Update()
    {
        //Move();
        TempoMove();
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

        GameManager.Mestre.AlterarPontois(50);
        CancelInvoke();
        gameObject.SetActive(false);
        Invoke("Destruir", 6f);
    }

    private void Move() // Movivento do Inimigo
    {
        float MoveZ = 0f;
        float MoveX = 0f;

        Vector3 mova;

        MoveX -= 1;

        moveInput = new Vector3(MoveX, 0, MoveZ);

        mova = (rb.position + moveInput * Time.fixedDeltaTime);
        rb.MovePosition(mova);
    }

    private void TempoMove() // O tempo que ele demora para parar
    {
        MoveTimer += Time.deltaTime;
        if (MoveTimer > 1f)
        {
            CancelInvoke("Move");
        }
    }

}

    


