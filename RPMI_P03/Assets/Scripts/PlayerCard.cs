using UnityEngine;

public class PlayerCard : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Acción al clicquear la carta del jugador
    private void OnMouseDrag()
    {
        // Nueva posición en eje z para que la carta no "desaparezca"
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;
        transform.position = newPosition;

        // transform.position = Input.mousePosition;  --> Lleva la carta cliqueada a la posicion (0,0,0)
        // transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);   --> La carta se va a la posición del ratón
    }

    // Coger carta
    private void OnMouseDown()
    {
        // print("clic");    -->  Comprobar que funciona al cliquear la carta del jugador
        GetComponent<SpriteRenderer>().sortingLayerName = "Carta Seleccionada";
    }

    // "Soltar" carta
    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().sortingLayerName = "Default";
    }
}
