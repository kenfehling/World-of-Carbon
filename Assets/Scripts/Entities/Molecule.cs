using UnityEngine;
using System.Collections;

public class Molecule : MonoBehaviour {

	// To be set by designer in object inspector of molecule prefabs
	public float standardEnthalpyChange;
	public string formula;
    public bool wildMolecule = true;

    void Update()
    {
        if (wildMolecule)
        {
            transform.GetComponent<Rigidbody2D>().AddForce(Random.insideUnitCircle * 2.25f);
        }
    }

	void OnTriggerEnter2D (Collider2D obj) {
        PlayerManager player = obj.GetComponent<PlayerManager>();
        Molecule molecule = obj.gameObject.GetComponent<Molecule>();

		if(molecule != null)
		{
            ReactionTableEntry reaction = null;

            if (!player)
                reaction = GameManager.reactionTable.GetReaction(this.formula, molecule.formula);
            else
                reaction = GameManager.reactionTable.GetReaction(this.formula, player.GetComposition());

			if (reaction != null) {
                if (player)
                {
                    if(reaction.pressure == player.GetPressure() && reaction.temperature == player.GetTemperature())
                        player.SetComposition(reaction.products[0]);
                }
                else
                {
                    //Non-Player Reaction
                }
			}
		}
	}
}
