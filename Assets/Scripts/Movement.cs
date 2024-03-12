using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float speed;
    Vector3 forward;
    [SerializeField] Rigidbody rb;
    bool right;
    bool left;
    bool up;
    int position;
    bool alive;
    [SerializeField] Material[] colors;
    float period = 0f;
    Material currentColor;

    // Start is called before the first frame update
    void Start()
    {
        currentColor = colors[Random.Range(0, 3)];
        GetComponent<MeshRenderer>().material = currentColor;
        speed = 8.0f;
        right = false;
        left = false;
        position = 0;
        alive = true;
        up = false;
    }

    // Update is called once per frame
    void Update()
    {
        right = Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D);
        left = Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A);
        period += UnityEngine.Time.deltaTime;
        if(right && position != 1)
        {
            transform.Translate(3.5f, 0, 0);
            position++;
        }
        else if(left && position != -1)
        {
            transform.Translate(-3.5f, 0, 0);
            position--;
        }
        if (period > 15.0f)
        {
            ChangeColor();
            period = 0.0f;
        }
        if (!up && Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(0f, 4.0f, 0f);
            up = true;
        }
        else if (up && Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(0f, -4.0f, 0f);
            up = false;
        }
    }
    void FixedUpdate()
    {
        if (!alive)
            return;
        forward = transform.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forward);

    }

    public void Die()
    {
        alive = false;
        Invoke("Restart", 2);
    }

    public void ChangeColor()
    {
        Material newColor = colors[Random.Range(0, 3)];
        while (newColor.name == currentColor.name)
            newColor = colors[Random.Range(0, 3)];
        currentColor = newColor;
        GetComponent<MeshRenderer>().material = currentColor;
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
