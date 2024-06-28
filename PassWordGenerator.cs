using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassWordGenerator
{

    public partial class PassWordGenerator : Form
    {
        //生成文字
        private const string ASCII_NUMBER = "0123456789";
        private const string ASCII_UPPER_ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string ASCII_LOWER_ALPHABET = "abcdefghijklmnopqrstuvwxyz";
        private const string ASCII_MARK = "!\"#$%&'()*+-/<=>?@;[]^";

        //パスワードパターン
        private const int PASSWORD_PATTERN_ALL = 0;
        private const int PASSWORD_PATTERN_UPPER_LOWER = 1;
        private const int PASSWORD_PATTERN_UPPER = 2;
        private const int PASSWORD_PATTERN_LOWER = 3;

        //ランダムクラス
        private static readonly Random random = new Random();

        public PassWordGenerator()
        {

            InitializeComponent();

            //イベントハンドラの設定
            SetEventHandler();

            //メールアドレスコンボボックスの設定
            SetMailList();

            //保存した設定の読み込み
            int data = File.Load(File.passwordLength);
            if (data != -1)
            {
                passwordLengthUpDown.Value = data;
            }

        }

        private void generatorBtn_Click(object sender, EventArgs e)
        {

            //チケット名
            string dataFolderName = nameTextBox.Text;
            //パスワードの生成
            string password = GeneratePassword();

            //パスワードに紐づくパスワード
            string mail = File.ReplaceNotUseFileName(this.mailCmb.Text);

            //フォルダ作成
            string directoryPath = Directory.GetCurrentDirectory() + "\\パスワード管理";
            File.SafeCreateDirectory(directoryPath);
            directoryPath += "\\" + mail;
            File.SafeCreateDirectory(directoryPath);

            //出力パス
            dataFolderName = File.ReplaceNotUseFileName(dataFolderName);
            string filePath = directoryPath + "\\" + dataFolderName + ".txt";
            //ファイルが存在する場合上書きするか確認
            if (System.IO.File.Exists(filePath))
            {
                DialogResult result = MessageBox.Show("このデータフォルダパスワードは既に存在します。\n上書きしますか？", "ファイルの上書き", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.No)
                {
                    return;
                }
            }
            try
            {
                //パスワードの書き込み
                using (StreamWriter sw = new StreamWriter(filePath, false))
                {
                    sw.WriteLine(password);
                }

            }
            catch (IOException ex)
            {

            }
            //テキストの起動
            System.Diagnostics.Process.Start("notepad.exe", filePath);

            //メールアドレスコンボボックスの設定
            SetMailList();
        }

        /// <summary>
        /// パスワードを返却する
        /// </summary>
        /// <returns>パスワード</returns>
        /// 2022/11/16 木村
        private string GeneratePassword()
        {
            string source = null;
            string password = null;
            //パスワードの組合せを行う
            switch (this.passwordPatternCmb.SelectedIndex)
            {
                case PASSWORD_PATTERN_ALL:
                    source = ASCII_NUMBER + ASCII_UPPER_ALPHABET + ASCII_LOWER_ALPHABET + ASCII_MARK;
                    password = ChoicePassword(ASCII_NUMBER) + ChoicePassword(ASCII_UPPER_ALPHABET) + ChoicePassword(ASCII_LOWER_ALPHABET) + ChoicePassword(ASCII_MARK);
                    break;

                case PASSWORD_PATTERN_UPPER_LOWER:
                    source = ASCII_NUMBER + ASCII_UPPER_ALPHABET + ASCII_LOWER_ALPHABET;
                    password = ChoicePassword(ASCII_NUMBER) + ChoicePassword(ASCII_UPPER_ALPHABET) + ChoicePassword(ASCII_LOWER_ALPHABET);
                    break;

                case PASSWORD_PATTERN_UPPER:
                    source = ASCII_NUMBER + ASCII_UPPER_ALPHABET;
                    password = ChoicePassword(ASCII_NUMBER) + ChoicePassword(ASCII_UPPER_ALPHABET);
                    break;

                case PASSWORD_PATTERN_LOWER:
                    source = ASCII_NUMBER + ASCII_LOWER_ALPHABET;
                    password = ChoicePassword(ASCII_NUMBER) + ChoicePassword(ASCII_LOWER_ALPHABET);
                    break;
            }

            //パスワードの生成
            int lentgh = Decimal.ToInt32(passwordLengthUpDown.Value) - password.Length;
            for (int i = 0; i < lentgh; i++)
            {
                password += ChoicePassword(source);
            }

            //パスワードの並び順をランダムにして返却する
            return string.Join("", password.OrderBy(n => random.Next()));
        }

        /// <summary>
        /// パスワードとなる文字を返却する
        /// </summary>
        /// <param name="source">パスワードになる文字列</param>
        /// <returns>パスワードとなる文字</returns>
        /// 2022/11/16 木村
        private string ChoicePassword(string source)
        {
            //取得する文字列から一文字ランダムにパスワードを返却する
            return source[random.Next(0, source.Length - 1)].ToString();
        }

        /// <summary>
        /// フォームクローズ処理
        /// </summary>
        /// <param name="sender">発生元</param>
        /// <param name="e">イベント</param>
        /// 2022/11/17 木村
        private void RandomPasswordGeneratorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //VPNユーザーリストを保存
            if (!File.Save(Decimal.ToInt32(passwordLengthUpDown.Value), File.passwordLength))
            {
                MessageBox.Show("データの保存に失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// イベントハンドラの設定
        /// </summary>
        /// 2022/11/17 木村
        private void SetEventHandler()
        {
            this.FormClosing += this.RandomPasswordGeneratorForm_FormClosing;
            this.passwordPatternCmb.SelectedIndex = 0;
        }

        /// <summary>
        /// パスワードに紐づくメールアドレスのフォルダ名をリストに設定
        /// </summary>
        /// 2023/04/02 木村
        private void SetMailList()
        {
            //メールアドレスリストを初期化
            this.mailCmb.Items.Clear();

            //パスワード管理配下の全てのフォルダ取得
            string directoryPath = Directory.GetCurrentDirectory() + "\\パスワード管理";
            File.SafeCreateDirectory(directoryPath);
            DirectoryInfo[] diAlls = new DirectoryInfo(directoryPath).GetDirectories();

            foreach (DirectoryInfo di in diAlls)
            {
                this.mailCmb.Items.Add(di.Name);
            }

        }

        /// <summary>
        /// メールアドレスのテキストの取得を行う
        /// </summary>
        /// 2023/04/02 木村
        private string GetMailText()
        {
            string mail = this.mailCmb.Text;
            if(mail == null || mail == "")
            {
                mail = "その他";
            }
            return mail;

        }

    }
}
