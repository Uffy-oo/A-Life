using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 单例模式，确保全局只有一个GameManager实例
    public static GameManager Instance;
    private int CurrentSemester = 1;
    private int CurrentGpa = 0;
    private int WeeksLeft = 16;
    private int CurrentStamina;
    private StudentController studentController;
    private Student student;

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
    }
    // 游戏开始的方法
    public void StartGame()
    {
        for (CurrentSemester = 1; CurrentSemester < 9; CurrentSemester++ ) {
            StartSemester();
            if (this.CurrentStamina == 0 || this.WeeksLeft == 0)
            {
                EndSemester();
                CurrentSemester++;
                CurrentGpa = student.GradeScale + CurrentGpa;
            }
        }

        EndGame();
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

        if (currentSemester < 2)
        {
            currentSemester++;
        }
        else
        {
            currentSemester = 1;
            if (currentYear < 4)
            {
                currentYear++;
            }
            else
            {
                EndGame();
                return;
            }
        }

        StartSemester(); // 开始下一个学期
    }

    public void EndGame()
    {
        // 游戏结束逻辑
        // 例如：显示最终成绩、成就等
    }
}