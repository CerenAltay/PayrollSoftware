using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSProject
{
    class PaySlip
    {
        private int month;
        private int year;

        enum MonthsOfYear{ JAN =1, FEB = 2, MAR, APR, MAY, JUNE, JULY, AUG, SEPT, OCT, NOV, DEC}

    public PaySlip (int payMonth, int payYear)
        {
            this.month = payMonth;
            this.year = payYear;
        }

    public void GeneratePaySlip (List <Staff> myStaff)
        {
            
            foreach (Staff f in myStaff)
            {
                string path;
                path = f.NameOfStaff+".txt";

                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("PAYSLIP FOR {0}, {1}", (MonthsOfYear)month,year);
                    sw.WriteLine("======================================");
                    sw.WriteLine("Name of Staff: {0}", f.NameOfStaff);
                    sw.WriteLine("Hours Worked: {0}", f.HoursWorked);
                    sw.WriteLine("");
                    sw.WriteLine("Basic Pay: ({0:C})", f.BasicPay);

                    foreach (Staff n in myStaff )
                    {
                        if (n.GetType() == typeof(Manager))

                            sw.WriteLine("Allowance: {0}", ((Manager)f).Allowance);

                        else if (n.GetType() == typeof(Admin))

                            sw.WriteLine("Overtime: {0}", ((Admin)f).Overtime);
                     }
                    sw.WriteLine("");
                    sw.WriteLine("======================================");
                    sw.WriteLine("Total Pay: {0}", f.TotalPay);
                    sw.WriteLine("======================================");
                    sw.Close();
                }
            }
        }


        public void GenerateSummary(List<Staff> myStaff)
        {
                     //LINQ**
                     var result = from f in myStaff
                     where f.HoursWorked < 10 orderby f.NameOfStaff ascending
                     select new { f.NameOfStaff, f.HoursWorked };

                     string path;
                     path = "summary.txt";
                      
                     using (StreamWriter sw = new StreamWriter(path))
                      {
                        sw.WriteLine("Staff with less than 10 working hours");
                        sw.WriteLine("");

                        foreach (var n in result)
                        sw.WriteLine("Name of Staff: {0}, Hours Worked: {1}", n.NameOfStaff, n.HoursWorked);

                        sw.Close();
                      }
       }

        public override string ToString()
        {
            return "\nNameOfStaff= " + NameOfStaff + "\nhourlyRate= " + hourlyRate + "\nhWorked= " + hWorked + "\nBasicPay= " + BasicPay + "\n\nTotalPay= " + TotalPay;

        }
    }
}
