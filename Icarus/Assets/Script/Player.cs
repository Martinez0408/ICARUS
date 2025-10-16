using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speedPrincipal = 5f; //Velocidade modo principal
    [SerializeField] float speedRapida = 6f;  //Velocidade modo Rapido
    [SerializeField] Bala[] Tiro = new Bala[1]; //Tiro Instacia
    [SerializeField] GameObject Spawn; //Spawn do tiro
    [SerializeField] float FireRate = 0.1f;
    bool direcao = true; //Direcao do modo Rapido
    public bool Modo = true; //Define o modo
    float FireTimer = 0f;

    private Rigidbody rb;
    private Vector3 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Modo == true)

        {
            Modoprincipal();
            Atirar();
        }

        else ModoRapidoMovimento();

    }

    void Update()
    {
        if (Modo == false)

        {
            ModoRapidoInput();
        }


        if (Input.GetKeyDown(KeyCode.Space))

        {
            Modo = !Modo;
        }
    }

    void Modoprincipal() //Movimento da Nave no modo principal
    {
        float MoveZ = 0f;
        float MoveX = 0f;
        {
            if (Input.GetKey(KeyCode.W)) MoveZ = 1f; ;
            if (Input.GetKey(KeyCode.A)) MoveX = -1f; ;
            if (Input.GetKey(KeyCode.S)) MoveZ = -1f; ;
            if (Input.GetKey(KeyCode.D)) MoveX = 1f; ;

            moveInput = new Vector3(MoveX, 0f, MoveZ);

            Vector3 Limite = (rb.position + moveInput * speedPrincipal * Time.fixedDeltaTime);
            Limite.z = Mathf.Clamp(Limite.z, -13.5f, 6f);
            Limite.x = Mathf.Clamp(Limite.x, -22f, 22f);
            rb.MovePosition(Limite);



        }
    }

    void Atirar()
    {
        FireTimer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && FireTimer >= FireRate)

        { GameObject novaBala = Instantiate(Tiro[0].gameObject, Spawn.transform.position, Spawn.transform.rotation);

            FireTimer = 0f;
        }
        
    }


   void ModoRapidoMovimento() //Movimento do Modo Rapido
        {
            moveInput = direcao ? new Vector3(0, 0, 1f) : new Vector3(0, 0, -1f);
          Vector3 Posicao = (rb.position + moveInput * speedRapida * Time.fixedDeltaTime);
        Posicao.z = Mathf.Clamp(Posicao.z, -13.5f, 6f);
        rb.MovePosition(Posicao);
        }

    void ModoRapidoInput() //Controles do Modo Rapido
    {

        if (Input.GetMouseButtonDown(0))
        {
            direcao = !direcao;
        }

        if (Input.GetMouseButtonDown(1))
        {
            direcao = !direcao;
        }
    }


}

