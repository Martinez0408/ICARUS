using UnityEngine;
using TMPro;
public class LeaderBoard : MonoBehaviour
{
    public TMP_Text Showpontos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Showpontos.text = $"GBZ        " + GameManager.Mestre.Pontos;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
