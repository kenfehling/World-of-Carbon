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
		var molecule = obj.gameObject.GetComponent<Molecule> ();
		if(molecule != null)
		{
			var reaction = GameManager.reactionTable.GetReaction (this.formula, molecule.formula);
			if (reaction != null) {
				foreach (string s in reaction.products)
					Debug.Log ("Create " + s);
			}
		}
	}
}