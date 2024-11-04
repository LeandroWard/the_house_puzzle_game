using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;
using System.Drawing;
using UnityEngine.EventSystems;

public class controlCajaFuerte : InteractObject
{
      // Asigna el Input Field desde el Inspector
    public GameObject cajaFuerte;
    public Animator puerta;
    private bool estaAbierta = false;
    [SerializeField] AudioSource sonidoAbrirCerrar;
    [SerializeField] string clave;
    [SerializeField] Canvas canvas;
    [SerializeField] CinemachineVirtualCamera cameara;
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TMP_Text mensajes;
    //[SerializeField] BoxCollider BoxCollider;
    string mensaje1 = "Clave correcta!";
    string mensaje2 = "Clave incorrecta, intenta nuevamente.";
    bool estaActivo = false;
    PlayerViewController _player;
    public GameObject door02;
    private bool inSelectInputField = false;


    //en el interactuar pregunta si esta abierta aplica la animacion cerrar

    public override void Interact(PlayerViewController player)
    {
        if (_player == null)
        {
            _player = player;
        }
        if (inputField == null)
        {
            if (estaAbierta)
            {
                Cerrar();
            }
            else
            {
                Animator doorAnimator = door02.GetComponent<Animator>();
                doorAnimator.SetTrigger("OpenDoor");
                AbrirCajaFuerte();
            }
        }


        if (!estaActivo)
        {
            Debug.Log("jofas");
            cameara.Priority = 3;
            estaActivo = true;
            _player.OnInteract(true);
            if (estaAbierta)
            {
                Debug.Log("esta abierta");
                 cameara.Priority = 0;
                 inputField.DeactivateInputField();
                 Cerrar();

            }
            else
            {
                Debug.Log("esta cerrada");
                cameara.Priority = 3;
                Debug.Log("esta cambio");
                inputField.ActivateInputField();
            }
        }
 
    }

    public void OnExitInteraction()
    {
        cameara.Priority = 0;
        estaActivo = false;
        if(_player != null) _player.OnInteract(false);
    }

    public void VerificarPalabra()
    {
        string textoIngresado = inputField.text;
        
        // Verifica si la palabra ingresada es "Rubik"
        if (textoIngresado.Equals(clave, System.StringComparison.OrdinalIgnoreCase))
        {
            mensajes.color = UnityEngine.Color.green;
            mensajes.text = mensaje1;
            Invoke("Borrar", 1f);
            Debug.Log("�Palabra correcta! Abriendo la caja fuerte...");
            inputField.DeactivateInputField();
            Animator doorAnimator = door02.GetComponent<Animator>();
            doorAnimator.SetTrigger("OpenDoor");
            gameObject.layer = 0;
            AbrirCajaFuerte();  // Llama a la funci�n para abrir la caja fuerte
           
        }
        else
        {
            mensajes.color = UnityEngine.Color.red;
            mensajes.text = mensaje2;
            Invoke("Borrar", 2f);
            inputField.text = "";
            inputField.ActivateInputField();
        }
    }
    public void Cerrar()
    {
        
        puerta.Play("Cerrar");
        inputField.DeactivateInputField();
        sonidoAbrirCerrar.Play();
        estaAbierta = false;
        cameara.Priority = 0;
        
    }
    private void AbrirCajaFuerte()
    {
        puerta.Play("Abrir");
        estaAbierta=true;
        cameara.Priority = 0;
        sonidoAbrirCerrar.Play();
        Destroy( inputField.gameObject);
       // BoxCollider.enabled = false;

        //transform.Find("botones").gameObject.SetActive(false);
        // Aqu� puedes poner la l�gica para abrir la caja fuerte, como activar una animaci�n o mover un objeto.
        //cajaFuerte.SetActive(false);  // Ejemplo: desactiva la caja fuerte
    }

    private void Borrar()
    {
        mensajes.text =string.Empty;

    }

    public void OnSelectInputField()
    {
        inSelectInputField = true;
    }
    public void OnDeselectInputField()
    {
        inSelectInputField = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // var eventSystem = EventSystem.current;
            // if (!eventSystem.alreadySelecting) eventSystem.SetSelectedGameObject (null);
            inputField.MoveTextEnd(false);
            OnExitInteraction();
        }
    }

}
