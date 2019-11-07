using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject ActivationAnimation;
    [SerializeField] GameObject[] Capsuls;
    [SerializeField] GameObject[] Let;
    [SerializeField] Text Task;

    int Score;
    int ForAssignment;
    int RandomNumberToDisable;

    private void Start()
    {
        AccidentallyDisconnectCapsules();
        AccidentallyDisconnectLet();
    }

    void AccidentallyDisconnectCapsules()
    {
        for (int indexC = 0; indexC < Capsuls.Length; indexC++)
        {
            RandomNumberToDisable = Random.Range(0, 7);
            if (RandomNumberToDisable == 4 || RandomNumberToDisable == 7 || RandomNumberToDisable == 0 || RandomNumberToDisable == 2 || RandomNumberToDisable == 1) ForAssignment++;
            else Capsuls[indexC].SetActive(false);
        }
        Task.text = (ForAssignment + "/0");
    }

    void AccidentallyDisconnectLet()
    {
        for (int indexL = 0; indexL < Let.Length; indexL++)
        {
            RandomNumberToDisable = Random.Range(0, 7);
            if (RandomNumberToDisable == 4 || RandomNumberToDisable == 7 || RandomNumberToDisable == 0 || RandomNumberToDisable == 2 || RandomNumberToDisable == 1) Let[indexL].SetActive(false);
        }
    }

    public void TaskPerformance()
    {
        Score++;
        Task.text = (ForAssignment + "/" + Score);
        if (Score >= ForAssignment) ActivationAnimation.GetComponent<Animator>().SetTrigger("TaskCompleted");
    }

    public void NextLevel()
    {
        if (Score >= ForAssignment) LevelRestart();
    }

    public void LevelRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}