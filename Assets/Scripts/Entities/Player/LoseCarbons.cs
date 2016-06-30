using UnityEngine;
using System.Collections;

public class LoseCarbons : MonoBehaviour {

    private PlayerManager player;

	void Start () {
        player = gameObject.GetComponent<PlayerManager>();
	}
	
	void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Wall"))
        {
            if(player.GetNumOfCarbons() > 1)
            {
                player.DecrementCarbons();
                Vector3 randomDirection = new Vector3(Random.value, Random.value, Random.value);
                GameObject lostCarbon = (GameObject)Instantiate(Resources.Load(ResourcePaths.FreeCarbonMolecule), transform.position, Quaternion.identity);
                lostCarbon.GetComponent<FlyTo>().setTarget(transform.position + randomDirection * 2.5f, false);
            }
        }
    }
}
