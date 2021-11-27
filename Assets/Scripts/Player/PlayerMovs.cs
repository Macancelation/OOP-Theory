using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovs : MonoBehaviour
{
    Rigidbody2D rb;
    float axisX, axisY;
    Vector2 axis;
    public float velocidad;
    public GameObject prefs;
    public Transform cañon;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        transform.position = Vector3.left * 7.35f;
    }

    private void Update()
    {
        axisX = Input.GetAxisRaw("Horizontal");
        axisY = Input.GetAxisRaw("Vertical");
        axis = new Vector2(axisX, axisY);
        if (Input.GetKeyDown(KeyCode.K)) Instanciar();
    }

    private void FixedUpdate()
    {
        rb.velocity = axis.normalized * velocidad;
    }

    void Instanciar()
    {
        Instantiate(prefs, cañon.position, prefs.transform.rotation);
    }
}
