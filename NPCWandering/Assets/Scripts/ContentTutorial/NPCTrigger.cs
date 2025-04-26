using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    private string _playerTag = "Player";
    private NPCContent _content;
    public VEDialogController _dialogController;
    
    void Start()
    {
        _dialogController = Object.FindObjectOfType<VEDialogController>();
        _content = GetComponent<NPCContent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //we only care about the player object.
        if (other.gameObject.tag != _playerTag) return;

        //we need to get the DialogContent
        List<string> content = _content.GetContent();

        //we need to feed the dialog content to the VEDialogController.
        _dialogController.InputDialog(content);
    }
}
