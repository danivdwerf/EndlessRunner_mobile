using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OpenKeyboard : MonoBehaviour 
{
	[SerializeField] private Text textToEdit;
	[SerializeField] private InputField inputField;
	private TouchScreenKeyboard keyboard;

	private void Keyboard()
	{
		if (inputField.isFocused)
		{
			keyboard = TouchScreenKeyboard.Open (textToEdit.text, TouchScreenKeyboardType.Default, false, false, false, false);
		}
	}
}
