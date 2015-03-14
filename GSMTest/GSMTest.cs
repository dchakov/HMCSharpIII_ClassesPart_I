namespace MobilePhone
{
    using System;
    using MobilePhone;

    public class GSMTest
    {
        public static void Main()
        {
            GSMTesting();
            Console.WriteLine();
            GSMCallHistoryTest();
        }
        private static void GSMTesting()
        {
            Console.BufferHeight = Console.BufferHeight = 80;
            GSM test1 = new GSM("E51", "Nokia");
            GSM test2 = new GSM("Galaxy Mini S3", "Samsung", 105);
            GSM test3 = new GSM("Xperia", "Sony", 200, "Ivan", new Battery(BatteryType.NiCd));
            GSM test4 = new GSM("Blade", "ZTE", 450, "Simo", new Battery(BatteryType.NiMH, 14, 8));
            GSM test5 = new GSM("IM", "Lenovo", 340, "Petko", new Battery(), new Display(345, 33));

            GSM[] tests = { test1, test2, test3, test4, test5 };
            foreach (var item in tests)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            Console.WriteLine(GSM.IPhone4S);
        }

        private static void GSMCallHistoryTest()
        {
            GSM testCalls = new GSM("Blade", "ZTE", 450, "Simo", new Battery(BatteryType.NiMH, 14, 8));

            testCalls.AddCall(new DateTime(2014,3,14,21,03,2), "+359899982345", 50);
            testCalls.AddCall(DateTime.Now, "+359899981702", 120);
            testCalls.AddCall(DateTime.Now, "+359899965334", 400);

            Console.WriteLine("Call history");
            foreach (var item in testCalls.CallHistory)
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine("Total price of call history:{0:F2}",testCalls.CallPrice(0.37m));
            Console.WriteLine();
            Console.WriteLine("Remove the longest call from history");
            int longestIndex = 0;
            uint callseconds = 0;
            for (int i = 0; i <testCalls.CallHistory.Count ; i++)
            {
                if (testCalls.CallHistory[i].Seconds > callseconds)
                {
                    callseconds = testCalls.CallHistory[i].Seconds;
                    longestIndex = i;
                }
            }
            testCalls.DeleteCall(longestIndex);
            foreach (var item in testCalls.CallHistory)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Total price of call history:{0:F2}", testCalls.CallPrice(0.37m));
            Console.WriteLine("Delete all call history");
            testCalls.CallHistoryClear();
            foreach (var item in testCalls.CallHistory)
            {
                Console.WriteLine(item);
            }
        }
    }
}