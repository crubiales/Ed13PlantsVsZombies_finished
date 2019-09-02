using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pea : MonoBehaviour
{
  // BUZÓN
  public float speed;
  public bool isTouching;

  private Animator myAnimator;
  // FIN DEL BUZÓN

  void Start()
  {
    myAnimator = GetComponentInChildren<Animator>();
    isTouching = false;
  }

  void Update()
  {
    /// Si no estamos tocando un zombie
    if (isTouching == false)
    {
      /// Nos vemos hacia la derecha
      transform.Translate(new Vector3(
        speed * Time.deltaTime, 0, 0));
    }
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    /// Si el tag del objeto contra el que nos hemos
    /// chocado NO es zombie, deja de ejectuar el código
    /// que sigue
    if (collision.gameObject.CompareTag("Zombies")
      == false) return;

    Debug
      .Log("Hemos chocado contra el objeto llamado "
      + collision.gameObject.name);
    /// En cuanto toque a un zombie, lanzo el trigger
    /// visual de "estoy tocando un objeto"
    myAnimator.SetTrigger("Touched");
    /// y me aseguro de que isTouching sea cierto para
    /// que deje de moverse hacia la derecha mientras
    /// explota
    isTouching = true;
    /// Me aseguro de destruir el guisante después
    /// de un cierto tiempo
    Destroy(gameObject, 0.8f);

    /// Después de empezar a destruirme, le hago daño
    /// al zombie
    /// Primero, compruebo si el zombie contra el que
    /// me he chocado tiene un componente de tipo Health
    Health zombieHealth = collision.gameObject.GetComponent<Health>();
    /// Si lo tiene
    if (zombieHealth != null)
    {
      zombieHealth.ReceiveDamage(2);
    }
  }

}
