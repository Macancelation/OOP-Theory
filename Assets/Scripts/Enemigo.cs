using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]

//------OOP--Herencia-------
public class Enemigo : MonoBehaviour
{
    //Componentes
    Rigidbody2D rb;
    SpriteRenderer sr;

    //Serializefield
    [SerializeField] int vida;
    [SerializeField] float velocidad;
    [SerializeField] string tagProyectil;
    [SerializeField] Color selecColor;
    //Privadas
    Vector2 fisicaMovimiento;
    bool activarVelocidad;
    PanelControl canvas;

    [SerializeField] UnityEvent enviarDa�o;
    [SerializeField] UnityEvent recibirDa�o;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        sr.color = selecColor;
        rb.gravityScale = 0;
        MyStart();
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<PanelControl>();
    }

    private void Update()
    {
        MyUpdate();
    }

    private void FixedUpdate()
    {
        MyFixedUpdate();
    }

    //-----OOP--Abstraction------
    protected void MoverEnemigo(Vector3 direccion)
    {
        rb.transform.Translate(direccion * velocidad * Time.fixedDeltaTime);
    }
    protected void InstruirColor(Color color)
    {
        sr.color = color;
    }

    //-----Property-------
    public void Da�o(int a)
    {
        Vida -= a;
        if (Vida <= 0)
        {
            Destroy(gameObject);
        }
    }
    protected int Vida { get=> vida; set=> vida=value; }
    protected Rigidbody2D Rigidbody { get => rb; set => rb = value; }

    //------OOP--Encapsulation----
    void EventoEnviarDa�o()
    {
        enviarDa�o?.Invoke();
        canvas.Vida();
    }
    void EventoRecibirDa�o()
    {
        recibirDa�o?.Invoke();
        canvas.Puntos(3);
        Da�o(1);
    }

    //-------OOP--

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) { EventoEnviarDa�o(); Destroy(gameObject); }
        if (collision.gameObject.CompareTag(tagProyectil)) { EventoRecibirDa�o(); Destroy(collision.gameObject); }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) { EventoEnviarDa�o();}
        if (collision.gameObject.CompareTag(tagProyectil)) { EventoRecibirDa�o(); Destroy(collision.gameObject); }
    }

    //Vistuales
    protected virtual void MyStart() { }
    protected virtual void MyUpdate() { }
    protected virtual void MyFixedUpdate() { }
}
