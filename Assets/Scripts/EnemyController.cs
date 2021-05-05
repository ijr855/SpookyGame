using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    [Header("Attributes")]//divder for organize
    public float lookRadius = 10f;

    [Header("Setup Fields")] //divder for organize
    Transform target;
    NavMeshAgent agent;
    public Animator anim;
    [SerializeField] public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("isSeen", false);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        if (!gameController) //if game controller is not assigned then assign gamecontroller 
            gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius){ //if distance of target is smaller or equal to look radius set the 
            agent.SetDestination(target.position); //set the agent to go after it
            anim.SetBool("isSeen", true);//set to be true
            if(distance <= agent.stoppingDistance){
                FaceTarget(); //face target
            }
        }else{
            anim.SetBool("isSeen", false); //-- 
        }
    }


    void FaceTarget(){
        Vector3 direction = (target.position - transform.position).normalized; //get direction of target
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z)); // get the rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f); //change the rotation to lookRotation -- Quaternion.Slerp to smooth the rotation
    }

    void OnDrawGizmosSelected(){ // be able to see where agent starts tracking player
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,lookRadius);
    }

        private void OnTriggerEnter(Collider other){
            if(other.gameObject.tag == "Player"){
                gameController.isDead = true;
                Debug.Log("Got Spooked and Died");
            }
        }
}
