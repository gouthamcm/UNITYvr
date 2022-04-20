using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.Threading.Tasks;
using UnityEngine.SceneManagement;
public class bowling : MonoBehaviour
{
    GameObject ball;
    int SCORE = 0;
    GameObject[] pins;
    private Vector3 ball_position;
    private Quaternion ball_rotation;
    private Vector3[] positions;
    private Quaternion[] rotations;
    private int TOTAL_FRAMES = 21;
    private int frames_completed = 0;

    private int[] score_array;
    private int COUNTER = 0;
    private int FLAG=0;
    private int total_score = 0;
    // Start is called before the first frame update
    public Text socreUI;
    public Text totalSocreUI;
    public Text framesDoneUI;
    void Start()
    {
        pins = GameObject.FindGameObjectsWithTag("pins");
        savePinsPositions();
        ball = this.gameObject;
        ball_position = ball.transform.position;
        ball_rotation = ball.transform.rotation;
        score_array = new int[10];
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        
        if (other.gameObject.name == "Pinobjects")
        {
            FLAG=1;
            StartCoroutine(wait());

        }
        else if (other.gameObject.name == "Plane")
        {
            if(FLAG==0)
            {
                wait_for_reset();
            }
            else{
                FLAG=0;
            }
            
        }
    }

    private void wait_for_reset()
    {

        
        frames_completed++;
        SCORE = 0;
        framesDoneUI.text = frames_completed.ToString();
        socreUI.text = SCORE.ToString();
        ResetBallPosition();
        if(frames_completed%2==0)
        {
            ResetPinPositions();
        }

    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(10);

        int score = CountPinsDown();
        Debug.Log("counted pins");
        frames_completed++;
        if (frames_completed <= 18)
        {
            if (frames_completed % 2 == 0)
            {
                ResetBallPosition();
                ResetPinPositions();
                total_score += score;
                score = 0;
                SCORE = 0;
            }
            else
            {
                if (score == 10)
                {
                    frames_completed++;
                    ResetPinPositions();
                    total_score += score;
                    score = 0;
                    SCORE = 0;
                }
                else
                {
                    total_score += score;
                    score = 0;
                    SCORE = 0;
                }
                ResetBallPosition();
            }
            
        }
        else
        {
            if (frames_completed % 3 == 0)
            {
                ResetBallPosition();
                ResetPinPositions();
                total_score += score;
                score = 0;
                SCORE = 0;

            }
            else
            {
                if (score == 10)
                {
                    frames_completed += 2;
                    ResetPinPositions();
                    total_score += score;
                    score = 0;
                    SCORE = 0;
                }
                else
                {
                    total_score += score;
                    score = 0;
                    SCORE = 0;
                }
                ResetBallPosition();
                if (frames_completed >= 23)
                {
                    score_array[COUNTER++] = total_score;
                }
            }
        }

        Debug.Log("frames completed");
        Debug.Log(frames_completed);

        framesDoneUI.text = frames_completed.ToString();
        totalSocreUI.text = total_score.ToString();

    }
    void savePinsPositions()
    {
        positions = new Vector3[pins.Length];
        rotations = new Quaternion[pins.Length];

        for (int i = 0; i < pins.Length; i++)
        {
            positions[i] = pins[i].transform.position;
            rotations[i] = pins[i].transform.rotation;
        }

    }
    int CountPinsDown()
    {
        for (int i = 0; i < pins.Length; i++)
        {
            if (pins[i].transform.eulerAngles.z > 5 && pins[i].transform.eulerAngles.z < 355 && pins[i].activeSelf)
            {
                SCORE++;
                pins[i].SetActive(false);
                // Destroy(pins[i]);
            }
        }
        Debug.Log("Score now");
        // Debug.Log(SCORE);
        socreUI.text = SCORE.ToString();
        return SCORE;
    }
    void ResetPinPositions()
    {
        for (int i = 0; i < pins.Length; i++)
        {

            Rigidbody pinRigidbody = pins[i].GetComponent<Rigidbody>();
            pins[i].transform.position = positions[i];
            pins[i].transform.rotation = rotations[i];
            // pins[i].CancelToppleCheck();
            pinRigidbody.velocity = Vector3.zero;
            pinRigidbody.angularVelocity = Vector3.zero;
            pins[i].gameObject.SetActive(true);
        }
    }
    void ResetBallPosition()
    {
        ball.transform.position = ball_position;
        ball.transform.rotation = ball_rotation;
        Rigidbody ballRigidBody = ball.GetComponent<Rigidbody>();
        ballRigidBody.velocity = Vector3.zero;
        ballRigidBody.angularVelocity = Vector3.zero;
    }
}
