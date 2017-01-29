using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ConfirmPopup : BasePopup 
{
	[SerializeField] UIText textConfirm;
	[SerializeField] GameObject btnConfirm;
	Action confirmAction;

	protected override void OnButtonClick (GameObject go)
	{
		if (go == btnConfirm) 
		{
			Close(confirmAction);
		}
	}

	public void Open(string confirmText, Action confirmAction)
	{
		textConfirm.text = confirmText;
		this.confirmAction = confirmAction;
		base.Open();
	}
}
