using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject cube;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float time;
    [SerializeField]
    private Vector3 target;

    [SerializeField]
    private float distance;

    private bool move;
    [SerializeField]
    private GameObject cam;
    [SerializeField]
    private TMP_InputField inputDistance;
    [SerializeField]
    private TMP_InputField inputSpeed;
    [SerializeField]
    private TMP_InputField inputTime;
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private GameObject Restart_button;


    private void Start()
    {
        inputDistance.text = 5.ToString();
        inputSpeed.text = 1.ToString();
        inputTime.text = 1.ToString();

        move = true;
    }

    public void Restart()
    {
        cube.SetActive(false);

        StopCoroutine(Coroutine());
        move = true;

        canvas.SetActive(true);
        Restart_button.SetActive(false);

        inputDistance.text = 5.ToString();
        inputSpeed.text = 1.ToString();
        inputTime.text = 1.ToString();
    }


    public void StartGame()
    {
        distance = float.Parse(inputDistance.text);
        speed = float.Parse(inputSpeed.text);
        time = float.Parse(inputTime.text);

        target = new Vector3(distance, 0, 0);
        move = true;
        canvas.SetActive(false);
        Restart_button.SetActive(true);
        StartCoroutine(Coroutine());
    }


    private void Update()
    {
        if (move == false && canvas.activeSelf == false)
        {
            move = true;
            StartCoroutine(Coroutine());
        }
    }

    private void LateUpdate()
    {
        cam.transform.position = cube.transform.position;
    }

    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(time);
        cube.SetActive(true);

        while (cube.transform.position != target && cube.activeSelf != false)
        {
            var step = speed * Time.deltaTime;
            cube.transform.position = Vector3.MoveTowards(cube.transform.position, target, step);

            yield return 0;

        }
        cube.SetActive(false);
        cube.transform.position = Vector3.zero;
        move = false;
    }
}
