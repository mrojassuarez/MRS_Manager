using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VirfacVsQA
{
    class Program
    {
        // Virfac
        //const string NAS_FolderName = "1_4_3";
        //const string NAS_Folder = "\\\\Geonx-fs\\PUBLIC\\Virfac_QA\\" + NAS_FolderName;
        //const string Virfac_FolderName = "Virfac_143";
        //const string Virfac_Folder = "C:\\Users\\212686427\\Documents\\Sources\\" + Virfac_FolderName + "\\VirfacApp\\bin\\Release";

        // iAM
        const string NAS_FolderName = "1_3_QA";
        const string NAS_Folder = "\\\\Geonx-fs\\PUBLIC\\Virfac_iAM_QA\\" + NAS_FolderName;
        const string Virfac_FolderName = "Virfac-AM";
        const string Virfac_Folder = "C:\\Users\\212686427\\Documents\\Sources\\" + Virfac_FolderName + "\\Virfac-iAM\\bin\\Release";
        static void Main(string[] args)
        {
            Console.Write(Virfac_FolderName+ " - Redmine Number: ");
            var newNameFolder = Console.ReadLine();


            Console.WriteLine("Just a little patience: ");
            string pathRedmine = Path.Combine(NAS_Folder, newNameFolder);
            if (!Directory.Exists(pathRedmine))
                Directory.CreateDirectory(pathRedmine);
          
            string[] directories = System.IO.Directory.GetDirectories(Virfac_Folder, "*.*", SearchOption.AllDirectories);

            Parallel.ForEach(directories, dirPath =>
            {
                var newDirectory = dirPath.Replace(Virfac_Folder, pathRedmine);
                if (!Directory.Exists(newDirectory))
                {
                    Directory.CreateDirectory(newDirectory);
                    Console.Write("\\");
                }
            });

            string[] files = System.IO.Directory.GetFiles(Virfac_Folder, "*.*", SearchOption.AllDirectories);

            Parallel.ForEach(files, newPath =>
            {
                var newFile = newPath.Replace(Virfac_Folder, pathRedmine);
                if (File.Exists(newFile))
                {
                    File.Delete(newFile);
                    Console.Write("-");
                }
                File.Copy(newPath, newFile);
                
                Console.Write("*");
            });

        }
    }
}
