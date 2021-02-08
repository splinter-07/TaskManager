using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TaskManager
{
    class Program
    {   
        static bool flag = true;
        static void Main(string[] args)
        {
            Process[] process =  Process.GetProcesses();
            OutputProcess(process);

            Console.WriteLine("Какой процесс вы хотите закрыть введите его ID или имя");
            string proc = Console.ReadLine();
            
            Console.Write(VerificationProcess(proc) ? GetProcessById(proc) : GetProcessByName(proc));
            Console.ReadKey();
        }
        
        static void OutputProcess(Process[] processes) 
        { 
                for (int i = 0; i < processes.Length; i++)
                {
                    Console.Write(processes[i].ProcessName + "\t");
                    Console.Write(processes[i].Id + "\t");
                    Console.WriteLine();
                }
        }
        
        static bool VerificationProcess(string proc) 
        {
            foreach (var symbol in proc)
                if (!char.IsDigit(symbol))
                {
                    flag = false;
                    break;
                }
            return flag;
        }
        
        static string GetProcessByName(string name) 
        {
            Process[] processes = Process.GetProcessesByName(name);
            foreach (Process anti in processes)
                if (anti.ProcessName.ToLower().Contains(name.ToLower())) {
                    anti.Kill(); 
                }
            
            return $"Процесс {name} удален";
        }
        
        static string GetProcessById(string id)
        {
            Process process = Process.GetProcessById(Convert.ToInt32(id));
            process.Kill();
            return $"Процесс {id} удален";
        }
    }
}
