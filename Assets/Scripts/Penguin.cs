using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Pathfinding;

/*
Penguin object to be attached to every penguin gameObject.
@author Sasha Buskin
*/
public class Penguin : MonoBehaviour
{
    public string name;
    public int fishingLevel = 0;
    public int nurtureLevel = 0;
    public int combatLevel = 0;
    public bool imFishing = false;
    public bool idle = true;
    public GameObject penguin;
    private Vector3 position;
    public float m_Speed = 5f;
    public Rigidbody2D rb;
    public Animator animatorWalk;
    public Animator animatorPopup;
    public int fishBag;
    public float fishTime;
    public FishCounter fishStock;
    public Vector2 targetPos;
    float rando;
    public Pointer pointer;
    public SelectSystem SelectSys;
    public GameObject Notibox;
    public TextMeshProUGUI Notitext;
    public FishingPath fp;
    public string penguinName;
    public AIPath fishingAIPath;
    public bool iftimeset = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animatorWalk = gameObject.GetComponent<Animator>();
        fishingAIPath = gameObject.GetComponent<AIPath>();
        fp = fishingAIPath.GetComponent<FishingPath>();
        fishBag = 0;
        Notitext = Notibox.GetComponent<TextMeshProUGUI>();
    }
    
    public Vector3 getPosition(){
        return position;
    }
    public bool isfishing(){
        return imFishing;
    }
    public bool isIdle(){
        return idle;
    }
        
/*
void Update(): Stops fishing animation if penguin stops fishing,
               functions as fishing timer that goes down each frame.

               Uses a random number between 0 and 500 in the castRod()
               function: if that random number is less than 3, a fish is caught.
               numbers can be modified for faster + slower fishing/level based.  

               Also deals with returning penguin to randomly movieng around 
               after fishing complete.

*/
    void Update()
    {      
        
        FishingController();
    }



    /*
void FishingController(): Runs in the Update function, controls fish time and calls castrod function with lvl of 1.


    */
    
    
    void FishingController(){
        if(imFishing == false) 
        {
        animatorWalk.SetBool("Fish", false); 
        }
        if(fishTime > 0){
            
            fishTime -= Time.deltaTime;
            print(fishTime);
            rando = Random.Range(0,500);
            castRod(1);
        }

        if(fishTime < 0){
            fishingAIPath.canMove = false;
            
            imFishing = false;
            idle = true;
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;      
            
            animatorWalk.SetBool("Fish", false);
            fishTime = 0;
        }
    }

    
   
    /*
public void goFishing(): sends penguin to one of 4 fishing spots,
                            sets relevant bools of penguin object to 
                            show fishing/not idle. Starts fishing animation.
                            Method also sets random fishing time,
                            between 15 and 50 seconds.
*/
    public void goFishing()
    {
        idle = false;
        imFishing = true;
        Debug.Log("Fishingggggg");
        print("idle: "+idle);
    
        
        
        float fishingSpot = Random.Range(1,5);

        switch(fishingSpot)
        {
            case 1: 
            targetPos = new Vector2(7.415773f, 9.553875f);
            break;
            case 2: 
            targetPos = new Vector2(11.13f, 12f);
            break;
            case 3: 
            targetPos = new Vector2(15.63f, 14f);
            break;
            case 4: 
            targetPos = new Vector2(17.13f, 17.3f);
            break;
            
        }
        
        fishingAIPath.canMove = true;
       // rb.constraints = RigidbodyConstraints2D.FreezeAll;
        //animatorWalk.SetBool("Fish", true);
       

    }
    
   
   /*
void castRod(int fishingLvl): function to control how much fish is caught depending on the penguins fishing level. Randomised
   
   
   */
   
   
    void castRod(int fishingLvl){
        
        //print("rando: "+rando);
        
        if(fishingLvl == 1){
          
            if (rando<3){
        
                Notitext.text = Notitext.text+"\n"+name+" has caught a fish!";
                fishStock.fishNum += 1;
                print("fishshtock: "+fishStock.fishNum); 
                fishBag += 1;
                print("fishbag: "+fishBag);
            }
        }
    }
}
