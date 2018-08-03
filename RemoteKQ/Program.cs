using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteKQ
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            Application.Run(new FrmMain());
        }

        static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            return LoadFromResource("Newtonsoft.Json.dll");
        }
        //加载资源转为Assembly程序集
        private static Assembly LoadFromResource(string resName)
        {
            Assembly ass = Assembly.GetExecutingAssembly();
            using (Stream stream = ass.GetManifestResourceStream("RemoteKQ.Resources." + resName))
            {
                byte[] bt = new byte[stream.Length];
                stream.Read(bt, 0, bt.Length);
                Assembly asm = Assembly.Load(bt);//转换流到程序集
                return asm;
            }
            return null;
        }
    }
}
