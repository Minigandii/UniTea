using UnityEngine;

public class Ladder : MonoBehaviour
{
    public bool isInRange;
    private PlayerMovement playerMovement;
    public BoxCollider2D collider;

    // Start is called before the first frame update
    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.isClimbing = true;
            collider.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            playerMovement.isClimbing = false;
            collider.isTrigger = false;
        }
    }
}
