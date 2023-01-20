using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Doodle : MonoBehaviour
{
    public static Doodle instance;                          
    private float horizontal;                                       
    public Rigidbody2D DoodleRigid;

    [SerializeField] private TextMeshProUGUI cloudText;
    [SerializeField] private TextMeshProUGUI cloudText2;
    [SerializeField] private TextMeshProUGUI cloudText3;

    private int cloaud;

    [SerializeField] private GameObject deadPanel;
    [SerializeField] private GameObject sound;

    void Start()
    {
        if (instance == null)                               
        {
            instance = this;                               
        }

        Time.timeScale = 1.0f;
    }

    
    void FixedUpdate()
    {
        if (Application.platform == RuntimePlatform.Android)    
        {
            horizontal = Input.acceleration.x;                  
        }

        DoodleRigid.velocity = new Vector2(Input.acceleration.x * 10f, DoodleRigid.velocity.y);     
    }

    public void OnCollisionEnter2D(Collision2D collision)       
    {
        if (collision.collider.name == "DeadZone")              
        {
            StartCoroutine(death());
            gameObject.SetActive(false);
        }
    }
    public void AddCloaud()
    {
        cloaud++;
        cloudText.text = cloaud.ToString();
        cloudText2.text = cloaud.ToString();
        cloudText3.text = cloaud.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Diam")
        {
            AddCloaud();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Jump")
        {
            Destroy(collision.gameObject);
        }
    }

    private IEnumerator death()
    {
        deadPanel.SetActive(true);

        Instantiate(sound, transform.position, Quaternion.identity);

        yield return new WaitForSeconds(1.2f);

    }
}
