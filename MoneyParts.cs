using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MoneyParts
{
    static void Main(string[] args)
    {
        Console.Write("Entrada: ");
        String monto = Console.ReadLine();
        List<List<int>> combinaciones = Build(monto);
        Console.WriteLine("Salida: " + Imprimir(combinaciones));
    }

    static List<List<int>> Build(string strMonto)
    {
        Decimal monto = Decimal.Parse(strMonto);
        Decimal saldo01, saldo02, saldo05, saldo1, saldo2, saldo5, saldo10, saldo20, saldo50, saldo100, saldo200;
        int num005, num01, num02, num05, num1, num2, num5, num10, num20, num50, num100, num200;
        num005 = num01 = num02 = num05 = num1 = num2 = num5 = num10 = num20 = num50 = num100 = num200 = 0;
        List<List<int>> combinaciones = new List<List<int>>();

        while (num200 * 200 <= monto)
        {
            saldo200 = monto - (num200 * 200);

            while(num100 * 100 <= saldo200)
            {
                saldo100 = saldo200 - (num100 * 100);

                while (num50 * 50 <= saldo100)
                {
                    saldo50 = saldo100 - (num50 * 50);

                    while (num20 * 20 <= saldo50)
                    {
                        saldo20 = saldo50 - (num20 * 20);

                        while (num10 * 10 <= saldo20)
                        {
                            saldo10 = saldo20 - (num10 * 10);

                            while (num5 * 5 <= saldo10)
                            {
                                saldo5 = saldo10 - (num5 * 5);

                                while (num2 * 2 <= saldo5)
                                {
                                    saldo2 = saldo5 - (num2 * 2);

                                    while (num1 * 1 <= saldo2)
                                    {
                                        saldo1 = saldo2 - num1;

                                        while (num05 * 0.5m <= saldo1)
                                        {
                                            saldo05 = saldo1 - (num05 * 0.5m);

                                            while (num02 * 0.2m <= saldo05)
                                            {
                                                saldo02 = saldo05 - (num02 * 0.2m);

                                                while (num01 * 0.1m <= saldo02)
                                                {
                                                    saldo01 = saldo02 - (num01 * 0.1m);

                                                    num005 = (int)(saldo01 / 0.05m);

                                                    List<int> combinacion = new List<int>();
                                                    combinacion.Add(num005);
                                                    combinacion.Add(num01);
                                                    combinacion.Add(num02);
                                                    combinacion.Add(num05);
                                                    combinacion.Add(num1);
                                                    combinacion.Add(num2);
                                                    combinacion.Add(num5);
                                                    combinacion.Add(num10);
                                                    combinacion.Add(num20);
                                                    combinacion.Add(num50);
                                                    combinacion.Add(num100);
                                                    combinacion.Add(num200);

                                                    combinaciones.Add(combinacion);

                                                    num01++;
                                                }
                                                num01 = 0;
                                                num02++;
                                            }
                                            num02 = 0;
                                            num05++;
                                        }
                                        num05 = 0;
                                        num1++;
                                    }
                                    num1 = 0;
                                    num2++;
                                }
                                num2 = 0;
                                num5++;
                            }
                            num5 = 0;
                            num10++;
                        }
                        num10 = 0;
                        num20++;
                    }
                    num20 = 0;
                    num50++;
                }
                num50 = 0;
                num100++;
            }
            num100 = 0;
            num200++;
        }
        return combinaciones;
    }

    static string Imprimir(List<List<int>> combinaciones)
    {
        StringBuilder sbCombinaciones = new StringBuilder();
        string strCombinacion, strCombinaciones;
        
        for (int i = 0; i < combinaciones.Count(); i++)
        {
            StringBuilder sbCombinacion = new StringBuilder();
            sbCombinacion.Append("[");
            for (int j = 0; j < combinaciones[i][11]; j++)
                sbCombinacion.Append("200, ");
            for (int j = 0; j < combinaciones[i][10]; j++)
                sbCombinacion.Append("100, ");
            for (int j = 0; j < combinaciones[i][9]; j++)
                sbCombinacion.Append("50, ");
            for (int j = 0; j < combinaciones[i][8]; j++)
                sbCombinacion.Append("20, ");
            for (int j = 0; j < combinaciones[i][7]; j++)
                sbCombinacion.Append("10, ");
            for (int j = 0; j < combinaciones[i][6]; j++)
                sbCombinacion.Append("5, ");
            for (int j = 0; j < combinaciones[i][5]; j++)
                sbCombinacion.Append("2, ");
            for (int j = 0; j < combinaciones[i][4]; j++)
                sbCombinacion.Append("1, ");
            for (int j = 0; j < combinaciones[i][3]; j++)
                sbCombinacion.Append("0.5, ");
            for (int j = 0; j < combinaciones[i][2]; j++)
                sbCombinacion.Append("0.2, ");
            for (int j = 0; j < combinaciones[i][1]; j++)
                sbCombinacion.Append("0.1, ");
            for (int j = 0; j < combinaciones[i][0]; j++)
                sbCombinacion.Append("0.05, ");

            strCombinacion = sbCombinacion.ToString();
            strCombinacion = strCombinacion.Substring(0, strCombinacion.Length - 2) + "]";

            sbCombinaciones.Append(strCombinacion + ", ");
        }

        strCombinaciones = sbCombinaciones.ToString();
        strCombinaciones = strCombinaciones.Substring(0, strCombinaciones.Length - 2);

        if (combinaciones.Count() > 0)
            strCombinaciones = "[" + strCombinaciones + "]";

        return strCombinaciones;
    }
}