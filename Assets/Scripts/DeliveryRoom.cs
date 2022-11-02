using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryRoom : MonoBehaviour
{

    public EmpireObj empire;

    public Transform target;
    public Vector3 CenterPos;
    public bool isBack = false;

    private float timer = 0;
    public float totlaTime = 300;
    private bool canAddNur = false;
    private float currentTime;
    private bool canToNur = false;
    public Text timeText;

    private Slider slider;
    public Text sliderText;

    public Text pinguBabyText;

    public float DoBabyTimer = 0;
    public float DoBabyTimerTotal = 300;


    // Start is called before the first frame update
    void Start()
    {
        CenterPos = transform.position;
        slider = transform.Find("Slider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        PingBabyToPingus();
        NurDoBaby();
        slider.maxValue = empire.pingusCount;
        if (Input.GetMouseButtonDown(0))
        {

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                
                if (hit.collider.name== "Igloo (2)")
                {
                    Debug.Log(isBack);
                    BackTrue(true);
                }

            }
        }

        pinguBabyText.text = empire.pinguBabyCount.ToString();
        if (empire.pingusCount == 0)
        {
            slider.enabled = false;
            sliderText.text = slider.value.ToString();
        }
        else
        {
            slider.enabled = true;
            sliderText.text = slider.value.ToString();
        }
        if (!isBack)
        {
            slider.value = 0;
            transform.position = Vector3.Lerp(this.transform.position, CenterPos, 0.1f);
            Camera.main.GetComponent<PanZoom>().enabled = true;
        }
        else
        {
            transform.position = Vector3.Lerp(this.transform.position, target.position, 0.1f);
            Camera.main.GetComponent<PanZoom>().enabled = false;
        }
        if (canToNur && currentTime <= 0)
        {
            canToNur = false;
        }
        if (canToNur)
        {
            timer += Time.deltaTime;
            if (timer >= 1)
            {
                timer = 0;
                currentTime--;
            }
            if (currentTime%totlaTime == 0&&canAddNur)
            {
                canAddNur = false;
                StartCoroutine("CanAddNurTrue");
                Debug.Log(currentTime % totlaTime);
                empire.nurturersCount++;
            }
        }
        
        string min = ((int)(currentTime / 60)).ToString();
        string seconds;
        int s = ((int)currentTime % 60);
        if (s > 10)
        {
            seconds = s.ToString();
        }
        else
        {
            seconds = "0"+s.ToString();
        }
        timeText.text = min + ":" + seconds;
    }
    public void BackTrue(bool back)
    {
        isBack = back;
    }
    
    public void PingusToNurturers()
    {
        if (slider.value != 0)
        {
            canToNur = true;
            empire.pingusCount-=(int)slider.value;
            int current = (int)(currentTime + totlaTime * slider.value);
            currentTime = current;
            StartCoroutine("CanAddNurTrue");
            
            timeText.text = current.ToString();
            slider.value = 0;
            //DoBabyTimer = (int)currentTime + DoBabyTimerTotal * empire.nurturersCount;

        }
    }
    IEnumerator CanAddNurTrue()
    {
        yield return new WaitForSeconds(1f);
        canAddNur = true;
    }
    public float toPingusTimer = 0;
    public float toPingusTimerTotal=300;
    public void PingBabyToPingus()
    {
        if (empire.pinguBabyCount > 0)
        {
            toPingusTimer += Time.deltaTime;
            if (toPingusTimer >= toPingusTimerTotal)
            {
                toPingusTimer = 0;
                empire.pinguBabyCount--;
                empire.pingusCount++;
            }
        }    
    }
    
    public void NurDoBaby()
    {
        if (empire.nurturersCount != 0)
        {
            DoBabyTimer += Time.deltaTime;
            if (DoBabyTimer >= DoBabyTimerTotal)
            {
                DoBabyTimer = 0;
                empire.pinguBabyCount+=empire.nurturersCount;
            }
            
        }
    }
}
