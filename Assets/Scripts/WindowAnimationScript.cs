using UnityEngine;

public class WindowAnimationScript : MonoBehaviour
{
	public CanvasGroup background;
	public RectTransform mainWindow;

	private void OnEnable()
	{
		background.alpha = 0;
		background.LeanAlpha(1, 1);

		mainWindow.localPosition = new Vector2(-Screen.width, 0);
		mainWindow.LeanMoveLocalX(0, 1).setEaseOutExpo().delay = 0.2f;
	}

	public void Close()
	{
		background.LeanAlpha(0, 1);
		mainWindow.LeanMoveLocalX(-Screen.width, 1).setEaseInExpo().setOnComplete(Complete);
	}

	private void Complete()
	{
		gameObject.SetActive(false);
	}
}
