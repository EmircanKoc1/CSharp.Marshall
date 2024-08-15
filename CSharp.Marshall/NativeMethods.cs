using System;
using System.Runtime.InteropServices;

namespace CSharp.Marshall
{
    internal class NativeMethods
    {
        [DllImport("user32.dll")]

        public static extern int MessageBox(
            int type,
            string message,
            string header,
            int option);

        private const uint WS_OVERLAPPEDWINDOW = 0x00CF0000; // Pencere stilini tanımlar
        private const uint WS_VISIBLE = 0x10000000; // Pencerenin görünür olmasını sağlar

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr CreateWindowEx(
        uint extendedStyle,
        string className,
        string windowName,
        uint style,
        int xPosition,
        int yPosition,
        int width,
        int height,
        IntPtr parentWindowHandle,
        IntPtr menuHandle,
        IntPtr instanceHandle,
        IntPtr parameters);


        public static void CreateWindow()
        {
            bool flag = true;

            while (flag)
            {
                
                // Pencere oluşturma
                IntPtr windowHandle = CreateWindowEx(
                       0, // extendedStyle: Genişletilmiş pencere stili (0: varsayılan)
                       "Static", // className: Pencere sınıfı adı (bu örnekte basit bir pencere sınıfı)
                       "Pencere Başlığı", // windowName: Pencerenin başlığı
                       WS_OVERLAPPEDWINDOW | WS_VISIBLE, // style: Pencerenin görünüm stili
                       100, // xPosition: Pencerenin ekran üzerindeki X konumu
                       100, // yPosition: Pencerenin ekran üzerindeki Y konumu
                       500, // width: Pencerenin genişliği
                       400, // height: Pencerenin yüksekliği
                       IntPtr.Zero, // parentWindowHandle: Ana pencere işaretçisi (bu örnekte ana pencere yok)
                       IntPtr.Zero, // menuHandle: Menü işaretçisi (bu örnekte menü yok)
                       IntPtr.Zero, // instanceHandle: Uygulama işaretçisi (bu örnekte geçersiz)
                       IntPtr.Zero // parameters: Ek parametreler (bu örnekte geçersiz)
                   );

                if (windowHandle != IntPtr.Zero)
                    Console.WriteLine("pencere oluşturuldu");
                else
                    Console.WriteLine("pencere oluşturulmadı");

            }


        }


    }
}
