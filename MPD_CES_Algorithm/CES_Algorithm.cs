using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPD_CES_Algorithm
{
    class CES_Algorithm
    {
        public List<Task> TaskList;
        public Int32 MainCycleDuration;

        public CES_Algorithm(Int32 mcd)
        {
            TaskList = new List<Task>();
            MainCycleDuration = mcd;
        }

        public void ClearObj()
        {
            if (TaskList != null)
                TaskList.Clear();
        }

        public void Go()
        {
            if (TaskList == null)
                throw new NullReferenceException("BŁĄD! lista tasków jest niezainicjalizowana ;( ");

            if ((MainCycleDuration % NWD()) != 0)
                throw new Exception("BŁĄD! Zła wartość głównego cyklu ...!");

            if (!SprawdzNWW())
                throw new Exception("BŁĄD! któryś z elementów nie spełnia założenia NWW!");

        }

        private int NWD()
        {
            var numbers = new int[TaskList.Count];

            for (var i = 0; i < TaskList.Count; ++i)
                numbers[i] = TaskList[i].T;

            return numbers.Aggregate(NWD);
        }

        private int NWD(int a, int b)
        {
            return b == 0 ? a : NWD(b, a % b);
        }

        private Boolean SprawdzNWW()
        {
            var result = true;

            foreach (var task in TaskList)
            {
                if (NWW(task.T, TaskList[TaskList.Count - 1].T) != TaskList[TaskList.Count - 1].T)
                    result = false;
            }
            return result;
        }

        private static int NWW(int a, int b)
        {
            int num1, num2;
            if (a > b)
            {
                num1 = a; num2 = b;
            }
            else
            {
                num1 = b; num2 = a;
            }

            for (var i = 1; i <= num2; i++)
            {
                if ((num1 * i) % num2 == 0)
                {
                    return i * num1;
                }
            }
            return num2;
        }
    }
}
