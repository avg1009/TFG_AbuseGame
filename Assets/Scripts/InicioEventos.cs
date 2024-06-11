using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioEventos : MonoBehaviour, Interactable
{
    [SerializeField] Dialog dialog;
    private float tiempoAntesDeDestruir = 5f;

    public void Interact()
    {
        StartCoroutine(DialogManager.Instance.ShowDialog(dialog));

        // Esperar un tiempo antes de destruir el objeto
        StartCoroutine(DestruirDespuesDeTiempo());
    }

    private IEnumerator DestruirDespuesDeTiempo()
    {
        yield return new WaitForSeconds(tiempoAntesDeDestruir);

        // Destruir el objeto (NPC) después de un tiempo específico
        Destroy(gameObject);
    }
}

