using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NetworkView))]
public class NetDebug : MonoBehaviour 
{
    private TextMesh textMesh;
    private string output;
    private Damagable damage;

	// Use this for initialization
	void Start ()
    {
        GameObject textGo = new GameObject("TextObject");
        textGo.transform.parent = this.transform;
        textGo.transform.localPosition = new Vector3(0, 1f, 0);
        textGo.transform.localScale = Vector3.one * 0.1f;
        textGo.transform.Rotate(Vector3.up * 180f);

        textGo.AddComponent<MeshRenderer>();

        textMesh = textGo.AddComponent<TextMesh>();
        textMesh.anchor = TextAnchor.UpperLeft;
        

        Font font = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        textGo.renderer.material = font.material;
        textMesh.font = font;

        textMesh.fontSize = 30;
        textMesh.fontStyle = FontStyle.Bold;
        



        damage = GetComponent<Damagable>();
	}
	
	// Update is called once per frame
	void Update () 
    {

        if(damage != null)
            textMesh.text = networkView.viewID + "\n" + (networkView.isMine ? "Mine" : "NotMine") + "\nDamage: " + damage.health + "\n " + output;
        else
            textMesh.text = networkView.viewID + "\n" + (networkView.isMine ? "Mine" : "NotMine") + "\n " + output;
	}
}
