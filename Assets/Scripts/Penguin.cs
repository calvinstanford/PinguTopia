using UnityEngine;
using UnityEngine.UI;

/*
Penguin object to be attached to every penguin gameObject.
@author Sasha Buskin
*/
public class Penguin : MonoBehaviour
{
    public string name;
    public bool imFishing = false;
    public bool idle = true;
    public GameObject penguin;
    private Vector3 position;
    public float m_Speed = 5f;
    private Rigidbody2D rb;
    public Animator animatorWalk;
    public Animator animatorPopup;
    public int fishBag;
    public float fishTime;
    public FishCounter fishStock;
    public Vector2 targetPos;
    float rando;
    public Pointer pointer;
    public SelectSystem SelectSys;
    public GameObject pt;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animatorWalk = gameObject.GetComponent<Animator>();
        fishBag = 0;
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
        PenguinSelector();
        FishingController();
    }




/*
void castRod (int fishingLvl): explained above.
*/
    public void closeStats(){
        animatorPopup.SetBool("OpenStat", false);
        SelectSys.selectedPenguin.pointer.pointerDeselect();
        SelectSys.selectorEnabled = true;
    }
    
   
   
   
   
   
 /*
public void PenguinSelector(): This function will run in Update(). If the system selector is enabled, 
                               this function detects touch and creates a raycast2d to detect specifically 
                               Penguin objects. It then begins the statbox popup animation, saves the 
                               clicked penguin object in the selectsystem, display a pointer over the seleted penguin,
                               and sets SelectSys.selectorEnabled = false; which disables the bug of selecting 
                               multiple. This is changed back to true when closing the statbox popup.
*/  
   
    public void PenguinSelector(){
    
    if(SelectSys.selectorEnabled == true){
             
            if(Input.GetMouseButtonDown(0)){
               
               RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
               print(hit.collider);
               if (hit.collider != null ){
                 
                    print("okfosar((((-----------------------------");
                    Debug.Log( hit.collider.name );
                    if (hit.collider.gameObject.GetComponent<Penguin>()){
                    
                        print("its a penguin!!!!!!");
                        animatorPopup.SetBool("OpenStat", true);
                        SelectSys.selectorEnabled = false;
                   
                        print("OOOOOOOOOOOZE");
                        SelectSys.selectedPenguin = hit.collider.gameObject.GetComponent<Penguin>();
                        if(!pointer.pointerArrow.gameObject.activeInHierarchy){
                            
                            SelectSys.selectedPenguin.pointer.pointerSelect();
                        }
                    }                
                }  
                Vector3 mousePosition = Input.mousePosition;
                print(mousePosition);

            }
        }
    
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
       
            imFishing = false;
            idle = true;
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;     
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
        
        Debug.Log("Fishingggggg");
        print("idle: "+idle);
    
        imFishing = true;
        
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
        
        rb.position = targetPos;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        animatorWalk.SetBool("Fish", true);

        float randomTime = Random.Range(15f,50f);
        fishTime = randomTime;

    }
    
   
   /*
void castRod(int fishingLvl): function to control how much fish is caught depending on the penguins fishing level.
   
   
   */
   
   
    void castRod(int fishingLvl){
        
        print("rando: "+rando);
        
        if(fishingLvl == 1){
          
            if (rando<3){
        
                fishStock.fishNum += 1;
                print("fishshtock: "+fishStock.fishNum); 
                fishBag += 1;
                print("fishbag: "+fishBag);
            }
        }
    }
}
