using UnityEngine;

public class Penguin : MonoBehaviour
{
    public string name;
    public bool imFishing = false;
    public bool idle = true;
    public GameObject penguin;
    private Vector3 position;
    public float m_Speed = 5f;
    private Rigidbody2D rb;
    public Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    animator = gameObject.GetComponent<Animator>();
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
    public void goFishing()
    {
        idle = false;
        Debug.Log("Fishingggggg");
        print("idle: "+idle);
    
        imFishing = true;
        Vector2 targetPos = new Vector2(7.415773f, 9.553875f);
        
        rb.position = targetPos;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        animator.SetBool("Fish", true);
     
    }
    

    void Update()
    {
        
    }
}
