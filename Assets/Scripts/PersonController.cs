using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour {

    public bool isAlive = true;
    [Range(0f, 180f)]
    public float DecayDelay = 30f;
    public Sprite SpriteAlive, SpriteSick, SpriteDead;
    Rigidbody2D rb2d;
    public float maximumVelocity = 5f;
    public float rotationDiff = 30f;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Move();
    }

    Vector2 GetMotionVector(float angleDegrees, float magnitude)
    {
        float cosinus = Mathf.Cos(Mathf.Deg2Rad * angleDegrees);
        float x = magnitude * cosinus;
        float y = Mathf.Sqrt((magnitude * magnitude) - (x * x));
        return new Vector2(x, y);
    }

    void GetSick()
    {

    }
    void Kill()
    {
        isAlive = false;
        StartCoroutine(Decay());
    }
    IEnumerator Decay()
    {
        yield return new WaitForSeconds(DecayDelay);
        Destroy(gameObject);
    }
    void Poke()
    {
        rb2d.velocity = new Vector2(Random.Range(-maximumVelocity, maximumVelocity), Random.Range(-maximumVelocity, maximumVelocity));
    }
    void Move()
    {
        Vector2 pastVelocity = rb2d.velocity;
        if (pastVelocity.x == 0 || pastVelocity.y == 0)
        {
            Poke();
            return;
        }
        float tan = pastVelocity.y / pastVelocity.x;
        float rads = Mathf.Atan(tan);
        float rotation = rads * Mathf.Rad2Deg;
        //float rotation = transform.rotation.eulerAngles.z;
        Debug.Log("Velocity rotation: " + rotation + "°");
        //rotation += Random.Range(-rotationDiff, rotationDiff);
        rotation += rotationDiff;
        rotation %= 360;
        Vector2 velocity = GetMotionVector(rotation, maximumVelocity);
        rb2d.velocity = velocity;
    }

}
