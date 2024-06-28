using System.IO;

namespace PassWordGenerator
{
    class File
    {

        /// <summary>パスワード桁数設定ファイル名</summary>
        public static string passwordLength = "\\passwordLength.dat";

        /// <summary>
        /// ディレクトリを作成する
        /// </summary>
        /// <param name="path">作成パス</param>
        /// <returns>ディレクトリ情報</returns>
        /// 2022/11/16 木村
        public static DirectoryInfo SafeCreateDirectory(string path)
        {
            //指定のパスにディレクトリが存在する場合、作成しない
            if (Directory.Exists(path))
            {
                return null;
            }

            //指定パスにディレクトリを作成し情報を返却
            return Directory.CreateDirectory(path);
        }

        /// <summary>
        /// バイナリ保存
        /// </summary>
        /// <param name="obj">保存データ</param>
        /// <param name="fileName">ファイル名</param>
        /// <returns>true 成功 false 失敗</returns>
        /// 2022/11/17 木村
        public static bool Save(int data, string fileName)
        {

            bool bResult = true;
            //フォルダ作成
            string directoryPath = Directory.GetCurrentDirectory() + "\\Setting";
            SafeCreateDirectory(directoryPath);

            //オブジェクトをバイナリ保存
            string filePath = directoryPath + fileName;
            try
            {
                using (var fs = new FileStream(filePath, FileMode.OpenOrCreate))
                    using(var bw = new BinaryWriter(fs))
                {
                    bw.Write(data);
                } 

            }
            catch (IOException e)
            {
                bResult = false;
            }
            
            return bResult;
        }

        /// <summary>
        /// 保存データの読み込み
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <returns>保存データ</returns>
        /// 2022/11/17 木村
        public static int Load(string fileName)
        {

            string filePath = Directory.GetCurrentDirectory() + "\\Setting" + fileName;
            int data = -1;
            //ファイルが存在しない場合、処理を行わない
            if (!System.IO.File.Exists(filePath))
            {
                return data;
            }
         
            try
            {
                using (var fs = new FileStream(filePath, FileMode.Open))
                    using(var br = new BinaryReader(fs))
                {
                    data = br.ReadInt32();
                }

            }
            catch (IOException e)
            {
            }
            
            return data;
        }

        /// <summary>
        /// 使用不能なファイル名を変換する
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <returns>使用可能なファイル名</returns>
        /// 2022/11/16 木村
        public static string ReplaceNotUseFileName(string fileName)
        {
            string newFileName = fileName.Replace("\\", "￥");
            newFileName = newFileName.Replace("/", "／");
            newFileName = newFileName.Replace(":", "：");
            newFileName = newFileName.Replace("*", "＊");
            newFileName = newFileName.Replace("?", "？");
            newFileName = newFileName.Replace("\"", "”");
            newFileName = newFileName.Replace("<", "＜");
            newFileName = newFileName.Replace(">", "＞");
            newFileName = newFileName.Replace("|", "｜");
            return newFileName;

        }
    }
    
}
