using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Bomb : MonoBehaviour
{
    
    public Transform player;
    public GameManager manager;
    public float explosionRadius;
    public float explosionStrength;
    public float upwardsModifier;
    public Material burnMaterial;
    public GameObject effect1;
    public GameObject effect2;
    public GameObject effect3;
    public GameObject[] effectList;
    private Collider[] hitTargets = new Collider[50];
    //public bool HorizontalTrajectory = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player.TryGetComponent(out PlayerMovement playerScript);
        manager = playerScript.gameManager;
        effectList[0] = effect1;
        effectList[1] = effect2;
        effectList[2] = effect3;
        transform.GetComponent<Rigidbody>().AddForce(player.forward, ForceMode.Force);
        //effect1.GetComponent<ParticleSystem>().totalTime
    }

    // Update is called once per frame
    void Update()
          
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        int effectNum = Random.Range(0, 2);
        GameObject currentEffect = Instantiate(effectList[effectNum], transform.position, Quaternion.Euler(0, 0, 0));

        //Explosion Guide:
        //https://gamedevbeginner.com/how-to-make-an-explosion-in-unity/
        int targetNum = Physics.OverlapSphereNonAlloc(transform.position, explosionRadius, hitTargets);
        
        

        if (targetNum > 0)
        for (int i = 0; i < targetNum; i++)
        {
                
                if (hitTargets[i].TryGetComponent(out Rigidbody rb) && hitTargets[i].gameObject.layer != 3 && hitTargets[i].gameObject.layer != 7)
                {
                    rb.AddExplosionForce(explosionStrength, transform.position, explosionRadius, upwardsModifier);
                    if (hitTargets[i].TryGetComponent(out Target target))
                    {
                        if (!target.isBurnt)
                        {
                            manager.addScore(1);
                            target.isBurnt = true;
                            Debug.Log("TARGETHIT");
                            Debug.Log(hitTargets[i]);
                            target.gameObject.GetComponent<Renderer>().material = burnMaterial;
                        }
                    }
                    
                } 
        }
        
        Destroy(currentEffect.gameObject, effectList[effectNum].GetComponent<ParticleSystem>().main.duration);
        Destroy(gameObject);
    }
}
