using System;

namespace CSharpVSCode
{
    class Program
    {       
        static void convert2DArray(int[, ] array) 
        {
            int col = array.GetLength(1);
            int row = array.GetLength(0);
            int[] retArray = new int[row * col];

            int k = 0;
            for (int i = 0; i < row; i++) {
                for (int j = 0; j < col; j++) {
                    retArray[k] = array[i,j];
                    k++;
                }
            }
            for (int i = 0; i < row * col; i++)
            {
                Console.Write("{0}\t", retArray[i]);
            }           
        }
        static void charOccurance(string str)
        {            
            Console.WriteLine("String: "+str);
            while (str.Length > 0) {
                if (str[0] == ' ')
                {
                    str = str.Replace(str[0].ToString(), string.Empty);
                }
                Console.Write(str[0] + " = ");
                int cal = 0;
                for (int j = 0; j < str.Length; j++) {
                    if (str[0] == str[j]) {
                    cal++;
                    }
                }
                Console.WriteLine(cal);
                str = str.Replace(str[0].ToString(), string.Empty);
            }
        }

        static int findAngle(double h, double m)
        {
            if (h == 12) h = 0;   
            else if (h > 12) h = h - 12;
            if (m == 60)
            {
                m = 0;
                h += 1;
                if(h>12)  h = h-12;
            }
            int hour_angle = (int)((h * 60 + m) * 0.5);
            int minute_angle = (int)(6 * m);
            int angle = Math.Abs(hour_angle - minute_angle);
            angle = Math.Min(360 - angle, angle);    
            return angle;
        }

        static int[] insert(int x, int pos, int[] arr)
        {   
            int n = arr.Length;
            int[] newarr = new int[n + 1];
            int i = 0;
            for (i = 0; i < n + 1; i++) {
                if (i < pos - 1)
                    newarr[i] = arr[i];
                else if (i == pos - 1)
                    newarr[i] = x;
                else
                    newarr[i] = arr[i - 1];
            }
            Console.WriteLine("...inserting....");
            for (i = 0; i < n + 1; i++)
                Console.Write(newarr[i] + " ");
            Console.WriteLine();
            return newarr;
        }
        static int dblLinear(int n)
        {
            int[] u = new int[n+4];
            u[0] = 1;
            int i = 0, k = 1;
            int count = 1;
            int x = 0, y = 0, z = 0;
            int last1 = 0, last2 = 0;
            bool isFirst = true;
            while (i <= u.Length)
            {
                if(count > n + 2){
                    Console.WriteLine("....Final array...");
                    for (i = 0; i < n + 1; i++){
                        Console.Write(u[i] + " ");
                    }
                    Console.WriteLine(" Result is: ");
                    return u[n];
                } 
                x = u[i];
                y = 2 * x + 1;
                z = 3 * x + 1;
                if (isFirst)
                {
                    u[k] = y; k++;
                    u[k] = z; k++;
                    count += 2;
                    i += 1;
                    isFirst = false;
                    continue;
                }
                last1 = u[k-1];
                last2 = u[k-2];

                if (last1 > y && last2 > y)
                {
                    u = insert(y, k - 1, u);                    
                }else if (last1 > y){
                    u = insert(y, k, u);
                }else{
                    u[k] = y;
                }
                k++;

                last1 = u[k-1];
                last2 = u[k-2];
                if (last1 > z && last2 > z)
                {
                    u = insert(z, k - 1, u);
                }else if (last1 > z){
                    u = insert(z, k, u);
                }else{
                    u[k] = z;
                }
                k++;
                count += 2;
                i += 1;
            }
            return 0;
        }
        static void Main(string[] args)
        {
            int [,] arr = new int [2,3] {
                                        {1, 2, 3} ,   
                                        {4, 5, 6}
                                     };
            //convert2DArray(arr);

            //string str = "hello world";
            //charOccurance(str);

           // Console.WriteLine(findAngle(13, 30));
            Console.WriteLine(" ");
            Console.WriteLine(dblLinear(10)); 
            
        }
    }
}
