using UnityEngine;
using UnityEngine.UI;

public class WidgetScript : MonoBehaviour
{
	public Text textLives;
	public Text textTimer;
	public Text textLivesGameWindow;
	public Text textTimerGameWindow;

	public GameObject textTimerObject;
	public GameObject useLifeButton;
	public GameObject refillLivesButton;

	public float timerLenght = 5;

	private float _currentTime;
	private int _countLives;

	private void Start()
	{
		_currentTime = timerLenght;
	}

	private void Update()
	{
		textLives.text = $"{_countLives}";
		textLivesGameWindow.text = $"{_countLives}";

		if (!textTimerObject.activeInHierarchy) textTimerObject.SetActive(true);
		if (!refillLivesButton.activeInHierarchy) refillLivesButton.SetActive(true);
		if (!useLifeButton.activeInHierarchy) useLifeButton.SetActive(true);

		if (_countLives == 0) if (useLifeButton.activeInHierarchy) useLifeButton.SetActive(false);

		if (_countLives == 5)
		{
			_currentTime = 0;
			textTimer.text = "Full";
			if (textTimerObject.activeInHierarchy) textTimerObject.SetActive(false);
			if (refillLivesButton.activeInHierarchy) refillLivesButton.SetActive(false);
		}

		else if (_currentTime > 0)
		{
			_currentTime -= Time.deltaTime;
			UpdateTimeText();
		}

		else if (_currentTime == 0 && _countLives < 5)
		{
			_countLives++;
			_currentTime = timerLenght;
		}
	}

	private void UpdateTimeText()
	{
		if (_currentTime < 0)
			_currentTime = 0;

		float minutes = Mathf.FloorToInt(_currentTime / 60);
		float seconds = Mathf.FloorToInt(_currentTime % 60);
		textTimer.text = string.Format("{0:00} : {1:00}", minutes, seconds);
		textTimerGameWindow.text = string.Format("{0:00} : {1:00}", minutes, seconds);
	}

	public void UseLife()
	{
		if (_countLives > 0)
		{
			_countLives--;
			_currentTime = timerLenght;
		}
	}

	public void RefillLives()
	{
		if (_countLives < 5)
		{
			_countLives++;
			_currentTime = timerLenght;
		}
	}
}
