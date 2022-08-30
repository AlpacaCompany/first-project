using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CPR_Script : MonoBehaviour
{
    AudioSource AS;
    public Camera cam;
    public TextMeshProUGUI Tex;
    public TextMeshProUGUI NumTex;
    int Num;

    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape)) //뒤로가기 키 입력
            {
                Application.Quit();
            }

        }
    }

    public void StartBtn() {
        StartCoroutine("Second");
        cam.backgroundColor = Color.gray;
        Tex.text = "Stop           Count";
        
    }

    public void StopBtn()
    {
        StopCoroutine("Second");
        Num = 0;
        NumTex.text = "";
        cam.backgroundColor = new Color(204f/255f, 204f/255f, 204f/255f);
        Tex.text = "Start           Count";
    }

    public void Touch() {
        string str = Tex.text.ToString();
        if(str[2] == 'a') {
            StartBtn();
        } else {
            StopBtn();
        }
    }

    IEnumerator Second()
    {
        yield return new WaitForSeconds(0.545f);
        AS.Play();
        if(Num == 30) {
            Num = 0;
        } else {
            Num++;
        }
        NumTex.text = Num.ToString();
        StartCoroutine("Second");
    }
}
