using UnityEngine;

public class RelayRace : MonoBehaviour
{
    public Transform[] runners; 
    public float speed = 5f; 
    public float passDistance = 1f; 
    private int currentRunnerIndex = 0; 
    private float animationTime = 0f; 

    void Update()
    {
        MoveCurrentRunner();
        AnimateCurrentRunner();
    }
    void MoveCurrentRunner()
    {
        int nextRunnerIndex = (currentRunnerIndex + 1) % runners.Length;
        Transform currentRunner = runners[currentRunnerIndex];
        Transform nextRunner = runners[nextRunnerIndex];

        currentRunner.LookAt(nextRunner.position);

        currentRunner.position = Vector3.MoveTowards(currentRunner.position, nextRunner.position, speed * Time.deltaTime);

        if (Vector3.Distance(currentRunner.position, nextRunner.position) < passDistance)
        {
           PassStick(currentRunner, nextRunner);
           currentRunnerIndex = nextRunnerIndex;
           animationTime = 0f;
        }
    }
    void PassStick(Transform fromRunner, Transform toRunner)
    {
       Transform stick = fromRunner.Find("righthandshoulder/Stick");
       if (stick != null)
        {
            stick.SetParent(toRunner.Find("righthandshoulder"), false);
        }
    }
    void AnimateCurrentRunner()
    {
        Transform currentRunner = runners[currentRunnerIndex];
        Transform leftHand = currentRunner.Find("lefthandshoulder");
        Transform rightHand = currentRunner.Find("righthandshoulder");
        Transform rightLeg = currentRunner.Find("righrlegbone");
        Transform leftLeg = currentRunner.Find("leftlegbone");
        
        float angle = Mathf.Sin(animationTime * speed) * 35; 
        animationTime += Time.deltaTime;

        if (leftHand != null)
            leftHand.localRotation = Quaternion.Euler(angle, 0, 0);
        if (rightHand != null)
            rightHand.localRotation = Quaternion.Euler(-angle, 0, 0);
        if (leftLeg != null)
            leftLeg.localRotation = Quaternion.Euler(angle, 0, 0);
        if (rightLeg != null)
            rightLeg.localRotation = Quaternion.Euler(-angle, 0, 0);
    }
 }