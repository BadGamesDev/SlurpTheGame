using UnityEngine;

public class Defender : MonoBehaviour
{
    public GameObject player;
    public float floatAmplitude = 0.5f;
    public float floatSpeed = 1.0f;

    private Vector3 initialLocalPosition;
    private float time = 0.0f;

    public int hitPoints;

    void Start()
    {
        player = GameObject.Find("Player");
        transform.parent = player.transform;

        hitPoints = 10;

        transform.localPosition = new Vector3(1.0f, 0.0f, 0.0f);

        initialLocalPosition = transform.localPosition;
    }

    void Update()
    {            
        time += Time.deltaTime;
        float yOffset = Mathf.Sin(time * floatSpeed) * floatAmplitude;
        transform.localPosition = initialLocalPosition + new Vector3(0.0f, yOffset, 0.0f);
    }
}