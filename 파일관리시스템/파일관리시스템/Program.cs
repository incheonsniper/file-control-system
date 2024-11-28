using System;
using System.IO;

namespace 파일관리시스템
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("파일 관리 시스템");
                Console.WriteLine("1. 파일 목록 보기");
                Console.WriteLine("2. 파일 생성");
                Console.WriteLine("3. 파일 삭제");
                Console.WriteLine("4. 파일 복사");
                Console.WriteLine("5. 파일 이동");
                Console.WriteLine("6. 종료");
                Console.Write("선택하세요: ");

                string? choice = Console.ReadLine(); // null 허용

                switch (choice)
                {
                    case "1":
                        ListFiles();
                        break;

                    case "2":
                        CreateFile();
                        break;

                    case "3":
                        DeleteFile();
                        break;

                    case "4":
                        CopyFile();
                        break;

                    case "5":
                        MoveFile();
                        break;

                    case "6":
                        Console.WriteLine("프로그램을 종료합니다.");
                        return;

                    default:
                        Console.WriteLine("잘못된 선택입니다. 다시 시도하세요.");
                        break;
                }
            }
        }

        static void ListFiles()
        {
            Console.WriteLine("파일 목록:");
            foreach (var file in Directory.GetFiles(Directory.GetCurrentDirectory()))
            {
                Console.WriteLine(Path.GetFileName(file));
            }
        }

        static void CreateFile()
        {
            Console.Write("생성할 파일 이름을 입력하세요: ");
            string? fileName = Console.ReadLine(); // null 허용
            if (!string.IsNullOrWhiteSpace(fileName))
            {
                File.Create(fileName).Close();
                Console.WriteLine($"{fileName} 파일이 생성되었습니다.");
            }
            else
            {
                Console.WriteLine("유효한 파일 이름을 입력하세요.");
            }
        }

        static void DeleteFile()
        {
            Console.Write("삭제할 파일 이름을 입력하세요: ");
            string? fileName = Console.ReadLine(); // null 허용
            if (!string.IsNullOrWhiteSpace(fileName))
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                    Console.WriteLine($"{fileName} 파일이 삭제되었습니다.");
                }
                else
                {
                    Console.WriteLine("파일이 존재하지 않습니다.");
                }
            }
            else
            {
                Console.WriteLine("유효한 파일 이름을 입력하세요.");
            }
        }

        static void CopyFile()
        {
            Console.Write("복사할 파일 이름을 입력하세요: ");
            string? sourceFileName = Console.ReadLine(); // null 허용
            Console.Write("새 파일 이름을 입력하세요: ");
            string? destFileName = Console.ReadLine(); // null 허용

            if (!string.IsNullOrWhiteSpace(sourceFileName) && !string.IsNullOrWhiteSpace(destFileName))
            {
                if (File.Exists(sourceFileName))
                {
                    File.Copy(sourceFileName, destFileName);
                    Console.WriteLine($"{sourceFileName} 파일이 {destFileName}로 복사되었습니다.");
                }
                else
                {
                    Console.WriteLine("원본 파일이 존재하지 않습니다.");
                }
            }
            else
            {
                Console.WriteLine("유효한 파일 이름을 입력하세요.");
            }
        }

        static void MoveFile()
        {
            Console.Write("이동할 파일 이름을 입력하세요: ");
            string? sourceFileName = Console.ReadLine(); // null 허용
            Console.Write("새 위치 파일 이름을 입력하세요: ");
            string? destFileName = Console.ReadLine(); // null 허용

            if (!string.IsNullOrWhiteSpace(sourceFileName) && !string.IsNullOrWhiteSpace(destFileName))
            {
                if (File.Exists(sourceFileName))
                {
                    File.Move(sourceFileName, destFileName);
                    Console.WriteLine($"{sourceFileName} 파일이 {destFileName}로 이동되었습니다.");
                }
                else
                {
                    Console.WriteLine("원본 파일이 존재하지 않습니다.");
                }
            }
            else
            {
                Console.WriteLine("유효한 파일 이름을 입력하세요.");
            }
        }
    }
}
