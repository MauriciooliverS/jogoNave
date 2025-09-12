using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    private float moveH;
    private float moveV;
    private Rigidbody rb;
    [SerializeField]private float velocidade;
    [SerializeField]private int pontos;
    [SerializeField]private bool estaVivo;
    [SerializeField]private Vector3 posicaoInicial;
    // Start is called before the first frame update
    void Start()
    {
        estaVivo = true;
        rb = GetComponent<Rigidbody>();
        velocidade = 20f;
        posicaoInicial = transform.position;   
    }
    // Update is called once per frame
    void Update()
    {
        if(estaVivo == true)
        {
            Time.timeScale = 1;
            moveH = Input.GetAxis("Horizontal");
            moveV = Input.GetAxis("Vertical");
            transform.position += new Vector3(moveH * Time.deltaTime * velocidade, moveV * Time.deltaTime * velocidade, 0 );
        
    }
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Meteoro"))
        {
             estaVivo = false;
             
            Time.timeScale = 0;
        } 
    }  
    public void VoltarParaPosicaoInicial()
    {
        transform.position = posicaoInicial;  // Reseta a posição do player para a posição inicial
    }     
    public int PegaPontos()
    {
        return pontos;
    }
    public bool VerificaVidaPlayer()
    {
        return estaVivo;
    }
}   