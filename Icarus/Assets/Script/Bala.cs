using UnityEngine;

public class Bala : MonoBehaviour

    
{
    [SerializeField] float speed = 10f;
    [SerializeField] float DeathTime = 1f;


   /* void Start()
    {
         Destroy(gameObject, 10f);
    } */

    void Kill()
    {
        DeathTime += Time.deltaTime;
        if (DeathTime > 10f)
            Destroy(gameObject);
    }
    void Move()
    {
        transform.position += Vector3.right *speed * Time.deltaTime; //Move a bala
    }
  

    void Update()
    {
        Move();
        Kill();
    }
}
