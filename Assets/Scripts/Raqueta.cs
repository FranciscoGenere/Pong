using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Raqueta : MonoBehaviour {

//Velocidad
public float velocidad = 30.0f;
//Eje vertical
public string eje;
//Eje horizontal
public string ejeX;
// Es llamado una vez cada fixed frame
void FixedUpdate () {
//Capto el valor del eje vertical de la raqueta
float v = Input.GetAxisRaw(eje);
float h = Input.GetAxisRaw(ejeX);
//Modifico la velocidad de la raqueta
GetComponent<Rigidbody2D>().velocity = new Vector2(h*velocidad, v * velocidad);
}
}