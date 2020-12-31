using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	public GameObject _breakablePlayer;

	// UI

	[SerializeField] GameObject _tapMessage;
	public Text _appleText;

	private Text _currentLevelText, _nextLevelText;

    private Image _fill;

	private int _level;

	private float _startDistance, _disatance;

	private GameObject _player, _finish, _hand,_rightArrow,_leftArrow;

	private TextMesh _levelNo;

	private PlayerController _playerController;
	private void Awake()
	{
		if (Instance == null)
			Instance = this;

		_playerController = GetComponent<PlayerController>();

		_currentLevelText = GameObject.Find("CurrentLevelText").GetComponent<Text>();
		_nextLevelText = GameObject.Find("NextLevelText").GetComponent<Text>();
		_fill = GameObject.Find("Fill").GetComponent<Image>();

		_player = GameObject.Find("Player");
		_finish = GameObject.Find("Finish");
		_hand = GameObject.Find("Hand");
		_rightArrow = GameObject.Find("RigthArrow");
		_leftArrow = GameObject.Find("LeftArrow");

		_levelNo = GameObject.Find("LevelNumber").GetComponent<TextMesh>();

		
	}
	private void Start()
	{
		_level = PlayerPrefs.GetInt("Level");

		_levelNo.text = "LEVEL " + _level;

		_nextLevelText.text = _level.ToString();
		_currentLevelText.text = _level.ToString();

		_startDistance = Vector3.Distance(_player.transform.position, _finish.transform.position);

		_tapMessage.SetActive(true);

		//SceneManager.LoadScene("Level" + _level);

	}
	private void Update()
	{
		_disatance = Vector3.Distance(_player.transform.position, _finish.transform.position);

		if (_player.transform.position.z < _finish.transform.position.z)
			_fill.fillAmount = 1 - (_disatance / _startDistance);

	}
	public void RemoveUI()
	{
		_hand.SetActive(false);
		_rightArrow.SetActive(false);
		_leftArrow.SetActive(false);
		_tapMessage.SetActive(false);

	}

}
