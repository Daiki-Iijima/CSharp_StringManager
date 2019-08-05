using System;
using System.Globalization;

namespace String_Manage
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== モードを選択してください ===");
            Console.WriteLine("nullチェック : NC");
            Console.WriteLine("日本語比較（ひら・カタ判別なし）: CJ");

            var getMode = Console.ReadLine();

            switch(getMode)
            {
                case "NC":
                    {
                        Console.WriteLine("=== nullチェックモード ===");

                        var getSt = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(getSt))
                        {
                            Console.WriteLine("null or 空文字列 or 空白文字列");

                            return;
                        }
                    }
                    break;
                case "CJ":
                    {
                        var serchWord_1 = Console.ReadLine();
                        var serchWord_2 = Console.ReadLine();

                        //  CulturInfo使用にはusingが必要
                        //  using System.Globalization;
                        var cultureInfo = new CultureInfo("jp-JP");

                        if (String.Compare(serchWord_1,serchWord_2,cultureInfo,CompareOptions.IgnoreKanaType) == 0)
                        {
                            Console.WriteLine("一致しています");
                        }
                        else
                        {
                            Console.WriteLine("一致していません");
                        }

                        return;
                    }
                    break;

            }

        }
    }
}
