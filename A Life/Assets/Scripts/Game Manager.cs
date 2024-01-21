using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    // 单例模式，确保全局只有一个GameManager实例
    public static GameManager Instance;
    private int CurrentSemester = 1;
    private float CurrentGpa = 0.0;
    private int WeeksLeft = 16;
    private int CurrentStamina;
    private StudentController studentController;
    private Student student;
    private int TotalConnection = 0;
    private bool shouldStartNextSemester = false;
    public TextMeshProUGUI endGameText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 保证在加载新场景时不销毁
        }
        else
        {
            Destroy(gameObject); // 如果已存在实例，则销毁新对象
        }
    }

    void Start()
    {
        StartGame();
    }

    private void Update()
    {
        this.CurrentStamina = student.Stamina;
        this.WeeksLeft = student.WeeksLeft;

        if (this.CurrentStamina == 0 || this.WeeksLeft == 0)
        {
            CurrentGpa = student.GradeScale + CurrentGpa;
            TotalConnection = student.LinkedonConnection + TotalConnection;
            EndSemester();
            shouldStartNextSemester = true;
        
        }

        if (shouldStartNextSemester && CurrentSemester < 8)
        {
            CurrentSemester++;
            StartSemester();
            shouldStartNextSemester = false;
        }
    }
    // 游戏开始的方法
    public void StartGame()
    {
        CurrentSemester = 1;
        StartSemester();

    }

    public void StartSemester()
    {
        // 初始化学期
        // 例如：初始化学生状态、课程、活动等

        // 处理学期内的事件和活动
        // 找到StudentController实例
        this.studentController = FindObjectOfType<StudentController>();
        this.student = studentController.getStudent();
    }

    public void EndSemester()
    {
        // 结束当前学期
        // 例如：保存学期成绩、更新状态等
       


      
    }

    public void EndGame()
    {
        // 游戏结束逻辑
        // 例如：显示最终成绩、成就等
        CurrentGpa = CurrentGpa / 8;
        
        endGameText.text = "Game Over: You've completed all semesters! WEEEEE!"

        if (CurrentGpa == 4.0)
        {
            endGameText.text = "You got accepted into Medical school. Now you are finally an average asian."
        }

        if (2.0 <= CurrentGpa < 3.0)
        {
            endGameText.text = "You've with officailly transformed into a LEGO"
        }
    }
}