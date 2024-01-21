using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    // 单例模式，确保全局只有一个GameManager实例
    public static GameManager Instance;
    public int CurrentSemester = 1;
    public float CurrentGpa = 0.0f;
    private int WeeksLeft = 16;
    private int CurrentStamina;
    private StudentController studentController;
    private Student student;
    private int TotalConnection = 0;
    public float TotalGpa = 0.0f;
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
       
        if (student.GradeScale >= 90)
        {
            CurrentGpa = 4.0f;
        }

        if (student.GradeScale >= 80 && student.GradeScale < 90)
        {
            CurrentGpa = 3.5f;
        }

        if (student.GradeScale >= 70 && student.GradeScale < 80)
        {
            CurrentGpa = 2.9f;
        }

        if (student.GradeScale >= 60 && student.GradeScale < 70)
        {
            CurrentGpa = 2.5f;
        }

        if (student.GradeScale >= 50 && student.GradeScale < 60)
        {
            CurrentGpa = 2.2f;
        }

        if (student.GradeScale < 50)
        {
            CurrentGpa = 0.5f;
        }

        TotalGpa = TotalGpa + CurrentGpa;
      
    }

    public void EndGame()
    {
        // 游戏结束逻辑
        // 例如：显示最终成绩、成就等

        TotalGpa = TotalGpa / 8;
        
        endGameText.text = "Game Over: You've completed all semesters! WEEEEE!";

        if (TotalGpa == 0.0)
        {
            endGameText.text = "You've just upgraded your living situation to 'Outdoor Enthusiast'!";
        }

        if (0.0 < TotalGpa && TotalGpa < 2.0)
        {
            endGameText.text = "You've with officailly transformed into a LEGOAT. C'est Quebec, on parle francais. C'est non-negotiable.";
        }

        if (2.0 <= TotalGpa && TotalGpa < 3.0 && TotalConnection < 600)
        {
            endGameText.text = "You're now the proud architect of golden arches at the one and only McGill'Dondald's! ";
        }

        if (2.0 <= TotalGpa && TotalGpa < 3.0 && TotalConnection >= 600)
        {
            endGameText.text = "It is not profession and not ethical. You've become an influencer!";
        }

        if (3.0 <= TotalGpa && TotalGpa < 4.0 && TotalConnection >= 500)
        {
            endGameText.text = "You're offered to work at the GREATEST COMPANY ever: Ubihard and Bmazon! We're so proud of you that even our coffee machine just brewed a fresh batch of 'Proud-uccino' in your honor!";
        }

        if (3.0 <= TotalGpa && TotalGpa < 4.0 && TotalConnection < 500)
        {
            endGameText.text = "";
        }

        if (TotalGpa == 4.0)
        {
            endGameText.text = "You got accepted into Medical school. Now you are finally an average asian.";
        }
    }
}