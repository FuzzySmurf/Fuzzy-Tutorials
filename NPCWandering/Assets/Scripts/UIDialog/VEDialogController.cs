using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace UIDialog
{
    public class VEDialogController : MonoBehaviour
    {
        protected VisualElement _root;
        protected VisualElement _dialogContent; //the Inner DialogBox
        protected string _dialogContentTxt = "DialogContent";
        protected string _dialogTxt = "dialog-text";
        protected Label _dialogTxtBox; //the txtbox of the dialog.

        protected VEDialogReader _dialogReader;
        private bool _isDialogEnabled = false;
        void Start()
        {
            _root = GetComponent<UIDocument>().rootVisualElement;
            _dialogContent = _root.Q<VisualElement>(_dialogContentTxt);
            _dialogTxtBox = _root.Q<Label>(_dialogTxt);

            //should register the clickevents on the txtbox.
            _dialogContent.RegisterCallback<MouseDownEvent>(OnDialogMouseDown);
            //start the scene with dialog turned off.
            DisplayDialog(false);
        }

        /// <summary>
        /// Should be triggered on every 'click' event from the Dialog Box.
        /// </summary>
        /// <param name="e"></param>
        private void OnDialogMouseDown(MouseDownEvent e)
        {
            //check if we're at maxCount b4 triggering an exit.
            bool bMaxCount = _dialogReader.isAtMaxContent;

            string txt = _dialogReader.NextContent(); ;
            _dialogTxtBox.text = txt;

            //if dialog is empty, check if we've reached the end. if so close.
            if (bMaxCount)
            {
                //turn off dialog box.
                DisplayDialog(false);

                //remove dialogReader.
                _dialogReader = null;
                return;
            }
        }

        /// <summary>
        /// Should be triggered when dialog first "Starts".
        /// </summary>
        public bool InputDialog(List<string> content)
        {
            _dialogReader = new VEDialogReader(content);
            //Grab the next piece of content in the list.
            string txt = _dialogReader.NextContent();
            //if no 'txt' is returned, assume we finished.
            if (string.IsNullOrEmpty(txt))
            {
                DisplayDialog(false);
                return false;
            }

            //assign txt to dialog box.
            _dialogTxtBox.text = txt;
            DisplayDialog(true);
            return true;
        }

        public void DisplayDialog(bool enableDialog)
        {
            _isDialogEnabled = enableDialog;
            if (enableDialog)
            {
                _root.style.display = DisplayStyle.Flex;
            } else
            {
                _root.style.display = DisplayStyle.None;
            }
        }

    }
}