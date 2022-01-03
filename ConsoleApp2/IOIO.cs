using System;
using System.IO;

namespace ConsoleApp2
{
    internal class IOIO
    {
        /// <summary>
        /// 驱动器
        /// </summary>
        public void DriveInfoT()
        {
            DriveInfo driveInfo = new DriveInfo("C"); // 实例化C盘的driveinfo
            Console.WriteLine($"driveInfo.GetType()\t{driveInfo.GetType()}");
            Console.WriteLine($"驱动器名称\t{driveInfo.Name}");
            Console.WriteLine($"驱动器类型\t{driveInfo.DriveType}");
            Console.WriteLine($"获取驱动器上存储空间的总大小（以字节为单位)\t{driveInfo.TotalSize}");
            Console.WriteLine($"驱动器可用空余\t{driveInfo.TotalFreeSpace}");
            Console.WriteLine($"文件系统名称\t{driveInfo.DriveFormat}");
            Console.WriteLine($"驱动器根目录\t{driveInfo.RootDirectory}");
            Console.WriteLine(GetFileSize(driveInfo.TotalSize));
            Console.WriteLine(ConvertSize.GetMB(driveInfo.TotalSize));
            DriveInfo[] driveInfos = DriveInfo.GetDrives();
            Array.ForEach<DriveInfo>(driveInfos, item =>
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.VolumeLabel);
            });
        }

        /// <summary>
        /// 目录操作
        /// </summary>
        public void DirectoryInfoT()
        {
            //如果要多次重用某个对象，请考虑使用的实例方法
            //（而不是 DirectoryInfo 类的相应静态方法 Directory ），
            //因为安全检查并不总是必需的。

            // 创造实例
            DirectoryInfo cc = new DirectoryInfo("./cc");
            DirectoryInfo ccff = new DirectoryInfo(@"./cc/ff");
            if (!cc.Exists) // 检查是否存在
            {
                cc.Create(); // 创建目录
            }
            if (!ccff.Exists)
            {
                ccff.Create();
            }
            cc.CreateSubdirectory("aa"); // 在当前目录创造子目录
            Console.WriteLine($"绝对路径\t{cc.FullName}");// 获取文件夹的绝对路径
            Console.WriteLine($"root\t{cc.Root}");
            Console.WriteLine($"目录名称{cc.Name}");
            FileInfo[] fileInfos = cc.GetFiles();
            DirectoryInfo[] directoryInfos = cc.GetDirectories();
            Console.WriteLine(directoryInfos.Length);
            Array.ForEach(fileInfos, item =>
            {
                Console.WriteLine(item);
            });
            Console.WriteLine(fileInfos.Length);
            Console.WriteLine($"移动前的路径{cc.Name}"); // cc
            if (Directory.Exists("./dd") == false) // 这是静态类Directory的方法，若dd目录已经存在，会引发IOException。
            {
                cc.MoveTo("./dd");
            }
            Console.WriteLine(cc.Name); // dd
            cc.Delete(true); // 删除目录，因为目录不为空所以需要true
            Console.WriteLine(cc.Exists);
            DirectoryInfo deskTop = new DirectoryInfo(@"C:\Users\苏月晟\Desktop");
            DirectoryInfo hIO = new DirectoryInfo(@"C:\Users\苏月晟\Desktop\HIO");
            if (!hIO.Exists)
            {
                hIO.Create();
            }
            Console.WriteLine(hIO.Name);
            Console.WriteLine(hIO.FullName);
            Console.WriteLine(hIO.Attributes);
            Console.WriteLine(hIO.Extension); // 文件夹拓展名
            Console.WriteLine($"创建时间\t{hIO.CreationTime}");
            Console.WriteLine($"写入时间\t{hIO.LastWriteTime}");
            Console.WriteLine($"访问时间\t{hIO.LastAccessTime}");

        }

        /// <summary>
        /// 文件大小单位转换
        /// </summary>
        /// <param name="byteCount">字节大小</param>
        /// <returns>根据字节大小返回适合的大小单位</returns>
        private string GetFileSize(double byteCount)
        {
            string size = "0 B";
            if (byteCount >= 1073741824.0)
                size = string.Format("{0:##.##}", byteCount / 1073741824.0) + " GB";
            else if (byteCount >= 1048576.0)
                size = string.Format("{0:##.##}", byteCount / 1048576.0) + " MB";
            else if (byteCount >= 1024.0)
                size = string.Format("{0:##.##}", byteCount / 1024.0) + " KB";
            else if (byteCount > 0 && byteCount < 1024.0)
                size = byteCount.ToString() + " B";

            return size;
        }
    }

    /// <summary>
    /// 字节大小转换
    /// </summary>
    public class ConvertSize
    {
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="b"> </param>
        /// <returns> </returns>
        public static string GetSize(double b)
        {
            String[] units = new String[] { "B", "KB", "MB", "GB", "TB", "PB" };
            double mod = 1024.0;
            int i = 0;
            while (b >= mod)
            {
                b /= mod;
                i++;
            }
            return Math.Round(b) + units[i];
        }

        /// <summary>
        /// 将B转换为TB
        /// </summary>
        /// <param name="b"> </param>
        /// <returns> </returns>
        private static string GetTB(long b)
        {
            for (int i = 0; i < 4; i++)
            {
                b /= 1024;
            }
            return b + "TB";
        }

        /// <summary>
        /// 将B转换为GB
        /// </summary>
        /// <param name="b"> </param>
        /// <returns> </returns>
        private static string GetGB(long b)
        {
            for (int i = 0; i < 3; i++)
            {
                b /= 1024;
            }
            return b + "GB";
        }

        /// <summary>
        /// 将B转换为MB
        /// </summary>
        /// <param name="b"> </param>
        /// <returns> </returns>
        public static string GetMB(long b)
        {
            decimal c = b;
            for (int i = 0; i < 2; i++)
            {
                c = Math.Round(c / 1024, 2);
                Console.WriteLine(c);
            }
            return c + "MB";
        }

        /// <summary>
        /// 格式化文件大小的C#方法
        /// </summary>
        /// <param name="filesize">文件的大小,传入的是一个bytes为单位的参数</param>
        /// <returns>格式化后的值</returns>
        public static string ForematFileSize(long filesize)
        {
            if (filesize < 0)
            {
                return "0 b";
            }
            else if (filesize >= 1024 * 1024 * 1024) //文件大小大于或等于1024MB
            {
                return string.Format("{0:0.00} GB", (double)filesize / (1024 * 1024 * 1024));
            }
            else if (filesize >= 1024 * 1024) //文件大小大于或等于1024KB
            {
                return string.Format("{0:0.00} MB", (double)filesize / (1024 * 1024));
            }
            else if (filesize >= 1024) //文件大小大于等于1024bytes
            {
                return string.Format("{0:0.00} KB", (double)filesize / 1024);
            }
            else
            {
                return string.Format("{0:0.00} b", filesize);
            }
        }
    }
}