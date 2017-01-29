using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ConfirmPopup : BasePopup 
{
	[SerializeField] UIText textConfirm;
	[SerializeField] UIButton btnConfirm;
	Action confirmAction;

	protected override void OnButtonClick (UIButton btn)
	{
		if (btn == btnConfirm) 
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
