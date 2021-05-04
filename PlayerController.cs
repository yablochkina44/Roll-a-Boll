using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //�������� �������
    public float speed = 20f;
    private Rigidbody rb;


    //���������� ��������� ������
    public Text countText, winText;
    private int count;

    //public GameObject player;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        winText.text = "";
        setCount();
    }

    // �������� �������
    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float xPos = moveHorizontal * speed;
        float moveVertical = Input.GetAxis("Vertical");
        float zPos = moveVertical * speed;

        rb.AddForce(xPos, 0.0f, zPos);
       

    }

    //����������� ������ ��� �������
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coins")
        { 
            Destroy(other.gameObject);
            count++;
            setCount();
        }
    }

    void setCount()
    {
        countText.text = "Couns: " + count.ToString();
        if (count >= 13)
        {
            winText.text = "Win!!!";
            GetComponent<Rigidbody>().AddForce(3 * Vector3.up, ForceMode.Impulse);
        }
    }


}