using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Sapoescurridizo : MonoBehaviour
{
    public float fuerzaSalto;
    public LayerMask capasuelo;
    public float velocidad;
    private Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider;
    private bool mirandoDerecha = true;
    public Animator animator;
    private void Start()
    { 
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        procesarMovimiento();
        ProcesarSalto();
    }
    void procesarMovimiento()
    {
        //movimiento
        float inputMovimiento = Input.GetAxis("Horizontal");






        //orientacion

        if (inputMovimiento != 0f)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
        rigidbody.velocity = new Vector2(inputMovimiento * velocidad, rigidbody.velocity.y);
        GestionarOrientacion(inputMovimiento);
    }

    void GestionarOrientacion(float inputMovimiento)
    {
        if (mirandoDerecha == true && inputMovimiento < 0 || mirandoDerecha == false && inputMovimiento > 0)
        {
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
    void ProcesarSalto()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && estaEnSuelo())
        {
            rigidbody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }
    bool estaEnSuelo()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, capasuelo);
        return raycastHit.collider != null;
    }

}
