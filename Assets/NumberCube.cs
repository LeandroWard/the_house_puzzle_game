using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumberCube : MonoBehaviour
{
    public TextMeshPro numberText; 

   
    public string GetNumber()
    {
        if (numberText != null)
        {
            Debug.LogWarning("el n�mero es" + numberText.text);
            return numberText.text;
            
        }
        else
        {
            Debug.LogWarning("El campo numberText no est� asignado en " + gameObject.name);
            return ""; 
        }
    }
}
