using System;
using System.IO;

namespace 파일관리시스템
{
    class Program
    {
        static string currentPath = Directory.GetCurrentDirectory();

        static void Main(string[] args)
        {
            while (true)
            {
                DisplayMenu();
                string? choice = Console.ReadLine();

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
                        EditFile();
                        break;

                    case "7":
                        ChangeFileExtension();
                        break;

                    case "8":
                        SetPath();
                        break;

                    case "9":
                        Console.WriteLine("프로그램을 종료합니다.");
                        return;

                    default:
                        Console.WriteLine("잘못된 선택입니다. 다시 시도하세요.");
                        break;
                }
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("파일 관리 시스템");
            Console.WriteLine($"현재 경로: {currentPath}");
            Console.WriteLine("1. 파일 목록 보기");
            Console.WriteLine("2. 파일 생성");
            Console.WriteLine("3. 파일 삭제");
            Console.WriteLine("4. 파일 복사");
            Console.WriteLine("5. 파일 이동");
            Console.WriteLine("6. 파일 수정");
            Console.WriteLine("7. 확장자 변경");
            Console.WriteLine("8. 경로 설정");
            Console.WriteLine("9. 종료");
            Console.Write("선택하세요: ");
        }

        static void ListFiles()
        {
            Console.WriteLine("파일 목록:");
            foreach (var file in Directory.GetFiles(currentPath))
            {
                Console.WriteLine(Path.GetFileName(file));
            }
        }

        static void CreateFile()
        {
            Console.Write("생성할 파일 이름을 입력하세요: ");
            string? fileName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(fileName))
            {
                File.Create(Path.Combine(currentPath, fileName)).Close();
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
            string? fileName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(fileName))
            {
                string filePath = Path.Combine(currentPath, fileName);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
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
            string? sourceFileName = Console.ReadLine();
            Console.Write("새 파일 이름을 입력하세요: ");
            string? destFileName = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(sourceFileName) && !string.IsNullOrWhiteSpace(destFileName))
            {
                string sourceFilePath = Path.Combine(currentPath, sourceFileName);
                string destFilePath = Path.Combine(currentPath, destFileName);

                if (File.Exists(sourceFilePath))
                {
                    File.Copy(sourceFilePath, destFilePath);
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
            string? sourceFileName = Console.ReadLine();
            Console.Write("새 위치 파일 이름을 입력하세요: ");
            string? destFileName = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(sourceFileName) && !string.IsNullOrWhiteSpace(destFileName))
            {
                string sourceFilePath = Path.Combine(currentPath, sourceFileName);
                string destFilePath = Path.Combine(currentPath, destFileName);

                if (File.Exists(sourceFilePath))
                {
                    File.Move(sourceFilePath, destFilePath);
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

        static void EditFile()
        {
            Console.Write("수정할 파일 이름을 입력하세요: ");
            string? fileName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(fileName))
            {
                string filePath = Path.Combine(currentPath, fileName);
                if (File.Exists(filePath))
                {
                    Console.Write("파일에 추가할 내용을 입력하세요: ");
                    string? content = Console.ReadLine();
                    File.AppendAllText(filePath, content + Environment.NewLine);
                    Console.WriteLine($"{fileName} 파일이 수정되었습니다.");
                }
                else
                {
                    Console.WriteLine("유효한 파일 이름을 입력하세요.");
                }
            }
        }

        static void ChangeFileExtension()
        {
            Console.Write("확장자를 변경할 파일 이름을 입력하세요: ");
            string? fileName = Console.ReadLine();
            Console.Write("새 확장자를 입력하세요 (예: .txt): ");
            string? newExtension = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(fileName) && !string.IsNullOrWhiteSpace(newExtension))
            {
                string filePath = Path.Combine(currentPath, fileName);
                if (File.Exists(filePath))
                {
                    string newFileName = Path.ChangeExtension(fileName, newExtension);
                    File.Move(filePath, Path.Combine(currentPath, newFileName));
                    Console.WriteLine($"{fileName}의 확장자가 {newFileName}로 변경되었습니다.");
                }
                else
                {
                    Console.WriteLine("유효한 파일 이름을 입력하세요.");
                }
            }
        }

        static void SetPath()
        {
            Console.Write("새 경로를 입력하세요: ");
            string? newPath = Console.ReadLine();
            if (Directory.Exists(newPath))
            {
                currentPath = newPath;
                Console.WriteLine($"현재 경로가 {currentPath}로 변경되었습니다.");
            }
            else
            {
                Console.WriteLine("유효한 경로를 입력하세요.");
            }
        }
    }
}
