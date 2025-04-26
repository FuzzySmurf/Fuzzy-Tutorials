using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCContent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public List<string> GetContent()
    {
        List<string> ret = new List<string>();
        ret.Add("Hey!");
        ret.Add("Did you hear?");
        ret.Add("Fuzzy has a new UIToolkit Dialog Tutorial Out!");
        ret.Add("We should check it out!");

        return ret;
    }
}
