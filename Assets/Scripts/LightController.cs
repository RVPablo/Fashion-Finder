using UnityEngine;

public class LightController : MonoBehaviour
{
    public int value; // La valeur de l'objet
    private Light objLight;

    void Start()
    {
        objLight = GetComponent<Light>();

        // V�rifiez si l'objet a un composant lumi�re
        if (objLight == null)
        {
            Debug.LogError("Pas de composant Light trouv� sur cet objet.");
            return;
        }

        Debug.Log("Light component found. Setting light color based on value.");

        // Changer la couleur de la lumi�re en fonction de la valeur
        switch (value)
        {
            case 1:
                objLight.color = Color.red;
                Debug.Log("Setting light color to red.");
                break;
            case 2:
                objLight.color = Color.green;
                Debug.Log("Setting light color to green.");
                break;
            case 3:
                objLight.color = Color.blue;
                Debug.Log("Setting light color to blue.");
                break;
            // Ajoutez d'autres cas si n�cessaire
            default:
                objLight.color = Color.white;
                Debug.Log("Setting light color to white.");
                break;
        }
    }
}
        