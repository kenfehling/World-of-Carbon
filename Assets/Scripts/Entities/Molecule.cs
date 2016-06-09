using UnityEngine;
using System.Collections;

public class Molecule : MonoBehaviour {

	// To be set by designer in object inspector of molecule prefabs
	public float standardEnthalpyChange;
	public string formula;
    public ParticleSystem ps;

	void OnCollisionEnter2D (Collision2D obj) {
		var molecule = obj.gameObject.GetComponent<Molecule> ();
		if(molecule != null)
		{
			var reaction = GameManager.reactionTable.GetReaction (this.formula, molecule.formula);
			if (reaction != null) {
				foreach (string s in reaction.products)
					Debug.Log ("Create " + s);
                Explosion();
			}
		}
	}

    void Explosion()
    {
        GameObject.Instantiate(ps).Play();

    }
}