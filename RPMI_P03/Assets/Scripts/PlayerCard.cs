using UnityEngine;

public class PlayerCard : MonoBehaviour
{
    public AudioSource takeCardAS;
    public AudioSource dropCardAS;

    // public GameObject                            ¡¡¡¡¡¡¡¡¡¡¡¡CONTINUAR!!!!!!!!!!!!!!!11
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
        GetComponent<BoxCollider2D>().enabled = false; // COMPROBAR

        if (!takeCardAS.isPlaying)
        {
            takeCardAS.pitch = Random.Range(0.95f, 1.05f);
            takeCardAS.Play();
        }
    }

    // "Soltar" carta
    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().sortingLayerName = "Default";
        GetComponent<BoxCollider2D>().enabled = true; // COMPROBAR
        if (!dropCardAS.isPlaying)
        {
            takeCardAS.pitch = Random.Range(0.95f, 1.05f);
            dropCardAS.Play();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision) // ARREGLAR
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!collision.gameObject.GetComponent<EnemyCard>().inCombat)
            {
               GameObject cs = Instantiate(CombatSistem, transform.position, Quaternion.identity);
                cs.GetComponent<CombatSistem>().playerCard = GetComponent<CardStats>();
                cs.GetComponent<CombatSistem>().enemyCard = GetComponent<CardStats>();
            }
        }
    }
  
    }
