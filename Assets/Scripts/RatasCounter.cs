using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class RatasCounter : MonoBehaviour
{
    public List<GameObject> ratasCounter = new List<GameObject>();
    public int ratasRestantes;
    public TextMeshProUGUI contadorVisual;

    void Start()
    {
        Transform[] todosLosHijos = GetComponentsInChildren<Transform>(true);

        foreach (Transform t in todosLosHijos)
        {
            // Evitamos añadir el objeto que tiene este script (el padre)
            if (t.gameObject != this.gameObject)
            {
                ratasCounter.Add(t.gameObject);
            }
        }

        ratasRestantes = ratasCounter.Count;
        ratasRestantes /= 3;
    }

    void Update()
    {
        ComprobarEstadoRatas();
    }

    private void ComprobarEstadoRatas()
    {
        ratasCounter.RemoveAll(rata => rata == null || !rata.activeInHierarchy);

        // 3. Actualizamos el contador visual en el Inspector
        ratasRestantes = ratasCounter.Count;
        ratasRestantes /= 3;
        contadorVisual.text = "Ratas: " + ratasRestantes.ToString();
    }
}