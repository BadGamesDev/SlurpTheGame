using UnityEngine;

public class Defender : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject player;

    public string defenderName;

    public Sprite[] defenderSprites;

    public float placement;
    public int hitPoints;

    public float floatAmplitude;
    public float floatSpeed;

    private Vector3 initialLocalPosition;
    private float time = 0.0f;

    void Start()
    {
        gameManager = GameObject.Find("GameController").GetComponent<GameManager>();

        floatAmplitude = 1.0f;
        floatSpeed = 2.0f;

        player = GameObject.Find("Player");
        transform.parent = player.transform;

        hitPoints = 4;

        transform.localPosition = new Vector3(placement, 0.2f, 0.0f);

        initialLocalPosition = transform.localPosition;
    }

    void Update()
    {            
        time += Time.deltaTime;
        float yOffset = Mathf.Sin(time * floatSpeed) * floatAmplitude;
        transform.localPosition = initialLocalPosition + new Vector3(0.0f, yOffset, 0.0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "ClosingWall")
        {
            gameManager.defenders.Remove(this);
            Destroy(gameObject);
        }
    }
}