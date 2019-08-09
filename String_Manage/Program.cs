using System;
using System.Globalization;
using System.Linq;

namespace String_Manage
{
    class MainClass
    {
        private enum Mode
        {
            NullCheck,
            JapaneseCheck,
            EnglishCheck,
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("=== モードを選択してください ===");

            Console.WriteLine("nullチェック : NC");
            Console.WriteLine("日本語比較（ひら・カタ判別なし）: CJ");
            Console.WriteLine("英字比較（大文字・小文字判別なし）: CE");
            Console.WriteLine("英字全て大文字: UP");
            Console.WriteLine("英字全て小文字: LO");
            Console.WriteLine("指定した文字が一文字でも含まれているか: CC");
            Console.WriteLine("空白の削除: TS");

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
                case "CE":  //  英字比較
                    {
                        Console.WriteLine("=== 英字比較（大文字・小文字判別なし）モード ===");
                        Console.WriteLine("一致しているか確認したい文字列を入力してください");

                        var serchWord_1 = GetString("= 1文字列目 =");

                        var serchWord_2 = GetString("= 2文字列目 =");

                        var cultureInfo = new CultureInfo("ja-JP");

                        if (String.Compare(serchWord_1, serchWord_2, cultureInfo, CompareOptions.IgnoreCase) == 0)
                        {
                            Console.WriteLine("一致しています");
                        }
                        else
                        {
                            Console.WriteLine("一致していません");
                        }
                    }
                    break;
                case "UP":　//   全て大文字にする
                    {
                        Console.WriteLine("=== 全て大文字化モード ===");

                        var getSt = GetString("= 大文字に変換したい文字列 =");

                        Console.WriteLine("-- 変換結果 --");

                        Console.WriteLine(getSt.ToUpper());
                    }
                    break;  
                case "LO":  //  全て小文字にする
                    {
                        Console.WriteLine("=== 全て小文字化モード ===");

                        var getSt = GetString("= 小文字に変換したい文字列 =");

                        Console.WriteLine("-- 変換結果 --");

                        Console.WriteLine(getSt.ToLower());
                    }
                    break;
                case "CC":  //  指定した文字が含まれているか
                    {
                        Console.WriteLine("=== 指定した文字が一文字でも含まれているかモード ===");

                        var targetSt = GetString("= 対象文字列 =");
                        var serchSt = GetString("= 検索したい文字 =");

                        //  todo : これすごいいらない気がするどうにかならないものか
                        var chars = serchSt.ToCharArray();

                        var isExist = targetSt.Any(c => Char.IsLower(chars[0]));

                        Console.WriteLine(isExist ? "含まれています":"含まれていません");
                    }
                    break;
                case "TS":  //  空白を排除する
                    {
                        Console.WriteLine("=== 空白の消去モード ===");

                        var targetSt = GetString("= 空白を消去したい文字列 =");

                        Console.WriteLine(targetSt.Trim());
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
