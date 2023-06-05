namespace Winform_Calculator
{
    public static class StrOpStr
    {

        public static decimal? num1 { get; set; }
        public static string? OP { get; set; }
        public static decimal? num2 { get; set; }
        public static bool PlusCheck { get; set; } = false;
        public static bool PlusCheck2 { get; set; } = false;
        public static string? Calculate(decimal num1, string op, decimal num2)
        {
            switch (op)
            {
                case "+": return Convert.ToString(num1 + num2);
                case "-": return Convert.ToString(num1 - num2);
                case "*": return Convert.ToString(num1 * num2);
                case "/": return Convert.ToString(num1 / num2);
            }
            return null;
        }

        public static char findOP(string labelString)
        {

            for (int i = 0; i < labelString.Length; i++)
            {
                if (labelString[i] == '+' || labelString[i] == '-' || labelString[i] == 'x' || labelString[i] == '/')
                {
                    return labelString[i];
                }
            }
            return ' ';
        }
        public static string Num1String(string labelString)
        {
            string tempNum1 = "";
            for (int i = 0; i < labelString.Length; i++)
            {
                if (labelString[i] == '+' || labelString[i] == '-' || labelString[i] == 'x' || labelString[i] == '/') return tempNum1;
                tempNum1 += labelString[i];
            }
            return tempNum1;
        }
        public static string Num2String(char op, string labelString)
        {
            string tempNum2 = "";
            for (int i = labelString.IndexOf(op) + 1; i < labelString.Length; i++)
            {
                tempNum2 += labelString[i];
            }
            return tempNum2;
        }

    }
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}