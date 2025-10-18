using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float speedPrincipal = 5f; //Velocidade modo principal
    [SerializeField] float speedRapida = 6f;  //Velocidade modo Rapido
    [SerializeField] Bala[] Tiro = new Bala[1]; //Tiro Instacia
    [SerializeField] GameObject Spawn; //Spawn do tiro
    [SerializeField] float FireRate = 0.1f;
    [SerializeField] float TrocaCD = 1f;
    bool direcao = true; //Direcao do modo Rapido
    public bool Modo = true; //Define o modo
    float FireTimer = 0f;
    GameManager GameManager;

    private Rigidbody rb;
    private Vector3 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }



    public void Derrota() //Oque acontece se o player morrer

    {
        gameObject.SetActive(false);
        Invoke("VaiproMenu", 1f); //Demora 3 segundos pra mudar a scene
       GameManager.Mestre.Pontos = 0; //Reseta os pontos pra zero                     (ATEN��O, CASO QUEIRA QUE MOSTRE NOS LEADERBOARDS MUDAR ESSA LINHA)
       
    }

    void Ganhar() //Ganha se apertar V
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            SceneManager.LoadScene("Victory");
        }

    }

    void TrocaDeformaCD()
    {
        TrocaCD += Time.deltaTime;
    }

    void VaiproMenu() //Muda a cena pra da de derrota
    {
        SceneManager.LoadScene("Lose");
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
        Ganhar();
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
        if ((Input.GetMouseButton(0)||(Input.GetKey(KeyCode.K))) && FireTimer >= FireRate)

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

