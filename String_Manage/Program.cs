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
            Console.WriteLine("英字比較（大文字・小文字判別なし）: CE");

            var getMode = Console.ReadLine();

            switch(getMode)
            {
                case "NC":　// nullチェック
                    {
                        var getSt = GetString("=== nullチェックモード ===");

                        if (string.IsNullOrWhiteSpace(getSt))
                        {
                            Console.WriteLine("null or 空文字列 or 空白文字列");

                            return;
                        }
                    }
                    break;
                case "CJ":  // 日本語比較（ひら・カタ判別なし
                    {
                        Console.WriteLine("=== 日本語比較（ひら・カタ判別なし）モード ===");
                        Console.WriteLine("一致しているか確認したい文字列を入力してください");

                        var serchWord_1 = GetString("= 1文字列目 =");

                        var serchWord_2 = GetString("= 2文字列目 =");

                        //  CulturInfo使用にはusingが必要
                        //  using System.Globalization;
                        var cultureInfo = new CultureInfo("ja-JP");

                        if (String.Compare(serchWord_1,serchWord_2,cultureInfo,CompareOptions.IgnoreKanaType) == 0)
                        {
                            Console.WriteLine("一致しています");
                        }
                        else
                        {
                            Console.WriteLine("一致していません");
                        }

                    }
                    break;
                case "CE":
                    {

                    }
                    break;

            }

        }

        /// <summary>
        /// アナウンスを表示した後に、文字列を受け取る
        /// </summary>
        /// <param name="writeSt"></param>
        /// <returns></returns>
        private static string GetString(string writeSt)
        {
            string getSt = null;

            Console.WriteLine(writeSt);

            getSt = Console.ReadLine();

            return getSt;
        }
    }
}
