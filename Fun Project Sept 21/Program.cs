using System;


namespace Fun_Project_Sept_21
{
    public class Employee
    {
        #region Employee Variables
        public string firstName = string.Empty;
        public string lastName = string.Empty;
        public int employeeID;
        #endregion

        #region Wage Variables
        public double basepay = 0;
        public double totalBase = 0;
        public double hours = 0;

        public double overtime = 0;
        public double totalOvertime = 0;
        public double overtimeHours = 0;

        public double differential = 0;
        public double totalDifferential = 0;
        public double differentialHours = 0;

        public double totalPay = 0;
        public double totalHours = 0;
        #endregion

        #region Deduction Variables
        public double medicalDed = 0;
        public double dentalDed = 0;
        public double visionDed = 0;
        public double miscPreDed = 0;

        public double miscPostDed = 0;

        public double preTaxDeductions = 0;
        public double preTaxSubTotal = 0;
        public double postTaxDeductions = 0;
        public double postTaxSubTotal = 0;
        #endregion

        #region Employee Initialization
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EmployeeID { get; set; }
        #endregion

        #region Wage Initialization
        public double Basepay { get; set; }
        public double TotalBase { get; set; }
        public double Hours { get; set; }

        public double Overtime { get; set; }
        public double TotalOvertime { get; set; }
        public double OvertimeHours { get; set; }

        public double Differential { get; set; }
        public double TotalDifferential { get; set; }
        public double DifferentialHours { get; set; }

        public double TotalPay { get; set; }
        public double TotalHours { get; set; }
        #endregion 

        #region PreTaxDeduction Initialization
        public double MedicalDed { get; set; }
        public double DentalDed { get; set; }
        public double VisionDed { get; set; }
        public double MiscPreDed { get; set; }
        public double PreTaxDeductions { get; set; }
        public double PreTaxSubTotal { get; set; }
        #endregion

        #region PostTaxDeduction Initialization
        public double MiscPostDed { get; set; }
        public double PostTaxDeductions { get; set; }
        public double PostTaxSubTotal { get; set; }
        #endregion

        #region Instance Declaration
        private Employee() { }
        public static readonly Employee employee = new Employee();
        #endregion
    }
    class Program
    {

        static void Main(string[] args)
        {
            EmployeeInfo();
            EmployeeWage();
            EmployeePreTaxDeductions();
            EmployeePostTaxDeductions();
            Display();
        }

        static void EmployeeInfo()
        {
            Console.WriteLine("Please enter the employee's last name: ");
            Employee.employee.lastName = Console.ReadLine();
            Console.WriteLine("Please enter the employee's first name: ");
            Employee.employee.firstName = Console.ReadLine();
            Console.WriteLine("Please enter the employee's ID number: ");
            Employee.employee.employeeID = Convert.ToInt32(Console.ReadLine());
        }

        static void EmployeeWage()
        {
            Console.WriteLine("Please enter the employee base wage:");
            Employee.employee.basepay = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("The employee base wage is: $" + Employee.employee.basepay);
            Console.WriteLine("How many hours worked? Overtime not included.");
            Employee.employee.hours = Convert.ToDouble(Console.ReadLine());
            Employee.employee.totalBase = (Employee.employee.basepay * Employee.employee.hours);

            Console.WriteLine("Does any differential apply?");
            char input = Convert.ToChar(Console.ReadLine());
            if (input == 'y')
            {
                do
                {
                    Console.WriteLine("Please enter the differential amount: ");
                    Employee.employee.differential = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("How many hours does the differential apply to? ");
                    Employee.employee.differentialHours = Convert.ToDouble(Console.ReadLine());
                    Employee.employee.totalDifferential += (Employee.employee.differential * Employee.employee.differentialHours);
                    Console.WriteLine("Would you like to add another differential?");
                    input = Convert.ToChar(Console.ReadLine());
                } while (input == 'y');
            }
            Console.WriteLine("Does any overtime apply?");
            input = Convert.ToChar(Console.ReadLine());
            if (input == 'y')
            {
                Console.WriteLine("Overtime is paid at 1.5 times the base wage");
                Employee.employee.overtime = Employee.employee.basepay * 1.5;
                Console.WriteLine("Hours of overtime applicable?");
                Employee.employee.overtimeHours = Convert.ToDouble(Console.ReadLine());
                Employee.employee.totalOvertime += (Employee.employee.overtime * Employee.employee.overtimeHours);
            }

            Employee.employee.totalPay = (Employee.employee.totalBase + Employee.employee.totalDifferential);
            Employee.employee.totalHours = (Employee.employee.hours + Employee.employee.overtimeHours);
        }
        static void EmployeePreTaxDeductions()
        {
            Console.WriteLine("Do any pre-tax deductions apply?");
            char input = Convert.ToChar(Console.ReadLine());
            if (input == 'y')
            {
                Console.WriteLine("Medical Premium deduction amount?");
                Employee.employee.medicalDed = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Dental Premium deduction amount?");
                Employee.employee.dentalDed = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Vision Premium deduction amount?");
                Employee.employee.visionDed = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Do any other pre-tax deductions apply?");
                input = Convert.ToChar(Console.ReadLine());
                if (input == 'y')
                {
                    Console.WriteLine("Miscellaneous deduction amount?");
                    Employee.employee.miscPreDed = Convert.ToDouble(Console.ReadLine());
                }
                Employee.employee.preTaxDeductions = (Employee.employee.medicalDed + Employee.employee.dentalDed + Employee.employee.visionDed + Employee.employee.miscPreDed);
                Employee.employee.preTaxSubTotal = (Employee.employee.totalPay - Employee.employee.preTaxDeductions);
            }
        }

        static void EmployeePostTaxDeductions()
        {
            Console.WriteLine("Do any post-tax deductions apply?");
            char input = Convert.ToChar(Console.ReadLine());
            if (input == 'y')
            {
                Console.WriteLine("Deduction amount?");
                Employee.employee.miscPostDed = Convert.ToDouble(Console.ReadLine());
            }
        }



        static void Display()
        {
            Console.WriteLine("Employee");
            Console.WriteLine();
            Console.WriteLine("Employee ID: " + Employee.employee.employeeID);
            Console.WriteLine("Employee: " + Employee.employee.firstName + " " + Employee.employee.lastName);
            Console.WriteLine();
            Console.WriteLine("Wages");
            Console.WriteLine();
            Console.WriteLine("Base pay: $" + Employee.employee.basepay);
            Console.WriteLine("Hours Worked: " + Employee.employee.totalHours);
            Console.WriteLine("Base wage earned: $" + Employee.employee.totalBase);
            Console.WriteLine("Overtime earned: $" + Employee.employee.totalOvertime);
            Console.WriteLine("Differentials earned: $" + Employee.employee.totalDifferential);
            Console.WriteLine("Total Pay earned: $" + Employee.employee.totalPay);
            Console.WriteLine();
            Console.WriteLine("Pre-tax Deductions");
            Console.WriteLine();
            Console.WriteLine("Medical Premium: $" + Employee.employee.medicalDed);
            Console.WriteLine("Dental Premium: $" + Employee.employee.dentalDed);
            Console.WriteLine("Vision Premium: $" + Employee.employee.visionDed);
            Console.WriteLine("Miscellaneous Premiums: $" + Employee.employee.miscPreDed);
            Console.WriteLine("Total Pre-tax Deductions: $" + Employee.employee.preTaxDeductions);
            Console.WriteLine("Pre-tax Subtotal: $" + Employee.employee.preTaxSubTotal);
            Console.WriteLine();
        }
    }
}



