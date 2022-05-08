    using UnityEngine;
    using UnityEngine.AI;
    using System.Collections;


    public class Patrol : MonoBehaviour {

        public Transform[] points;
        public float reactionTime = 0.005f; 
        public bool searchingForPlayer = false;
        public float reactionFactor = 20f;

        private int destPoint = 0;
        private NavMeshAgent agent;
        private AIFoV fov;
        private float distance;

        Transform patrolAI;


        void Start () {
            agent = GetComponent<NavMeshAgent>();
            fov = GetComponent<AIFoV>();

            // Disabling auto-braking allows for continuous movement
            // between points (ie, the agent doesn't slow down as it
            // approaches a destination point).
            agent.autoBraking = false;

            GotoNextPoint();
        }


        void GotoNextPoint() {
            // Returns if no points have been set up
            if (points.Length == 0)
                return;

            // Set the agent to go to the currently selected destination.
            agent.destination = points[destPoint].position;

            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            destPoint = (destPoint + 1) % points.Length;
        }


        public float eyesOnPlayerTimer = 0;
        void Update () {
            if(fov.canSeePlayer == true){
                distance = Vector3.Distance(this.transform.position, fov.player.position);
                eyesOnPlayerTimer += Time.deltaTime;
                Debug.Log("reactionTime * distance: " + (reactionTime * distance / reactionFactor));
                if(eyesOnPlayerTimer > reactionTime * distance / reactionFactor){
                    searchingForPlayer = true;
                    agent.destination = fov.player.position;
                }
            } else {
                // reset the eyesOnPlayerTimer if we lose sight of the player
                eyesOnPlayerTimer = 0;
                
            }

            // Choose the next destination point when the agent gets
            // close to the current one.
            if (!agent.pathPending && agent.remainingDistance < 0.5f){
                //GotoNextPoint();
                StartCoroutine(ConfusedAI());
            }
        }

        IEnumerator ConfusedAI(){
            if(searchingForPlayer){
                Vector3 currentSearchArea = this.transform.position;
                agent.destination = currentSearchArea;
                this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, this.transform.localRotation.y + 30, 0), Time.deltaTime*10);
                agent.destination = currentSearchArea;
                yield return new WaitForSeconds(1);
                this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, this.transform.localRotation.y - 180, 0), Time.deltaTime*10);
                yield return new WaitForSeconds(2);
                searchingForPlayer = false;
            }
            GotoNextPoint();
        }
    }