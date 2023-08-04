using System;
using Microsoft.VisualBasic;

namespace SudokuSolver
{
    class Program
    {

        // static bool IsSafe(int[,] board, int row, int col, int num)
        // {
        //     // Kiểm tra xem số num có hợp lệ để điền vào vị trí (row, col) hay không

        //     // Kiểm tra hàng
        //     for (int i = 0; i < 9; i++)
        //     {
        //         if (board[row, i] == num)
        //             return false;
        //     }

        //     // Kiểm tra cột
        //     for (int i = 0; i < 9; i++)
        //     {
        //         if (board[i, col] == num)
        //             return false;
        //     }

        //     // Kiểm tra vùng 3x3
        //     int startRow = 3 * (row / 3);
        //     int startCol = 3 * (col / 3);
        //     for (int i = 0; i < 3; i++)
        //     {
        //         for (int j = 0; j < 3; j++)
        //         {
        //             if (board[startRow + i, startCol + j] == num)
        //                 return false;
        //         }
        //     }

        //     return true;
        // }

        // static bool SolveSudoku(int[,] board)
        // {
        //     int row = -1;
        //     int col = -1;
        //     bool isEmpty = true;

        //     // Tìm ô trống (có giá trị 0) trong bảng Sudoku
        //     for (int i = 0; i < 9; i++)
        //     {
        //         for (int j = 0; j < 9; j++)
        //         {
        //             if (board[i, j] == 0)
        //             {
        //                 row = i;
        //                 col = j;
        //                 isEmpty = false;
        //                 break;
        //             }
        //         }
        //         if (!isEmpty)
        //             break;
        //     }

        //     // Nếu không còn ô trống, bảng đã được điền đầy đủ và đã giải xong
        //     if (isEmpty)
        //         return true;

        //     // Thử điền các số từ 1 đến 9 vào ô trống
        //     for (int num = 1; num <= 9; num++)
        //     {
        //         if (IsSafe(board, row, col, num))
        //         {
        //             board[row, col] = num;

        //             // Đệ quy giải quyết bài đố cho ô tiếp theo
        //             if (SolveSudoku(board))
        //                 return true;

        //             // Nếu không tìm được lời giải với số này, đặt lại ô thành trống và thử số khác
        //             board[row, col] = 0;
        //         }
        //     }

        //     return false; // Nếu không có số nào hợp lệ, quay lại bước trước
        // }

        // static void PrintBoard(int[,] board)
        // {
        //     for (int i = 0; i < 9; i++)
        //     {
        //         for (int j = 0; j < 9; j++)
        //         {
        //             Console.Write(board[i, j] + " ");
        //         }
        //         Console.WriteLine();
        //     }
        // }
        // public static int[,] board = new int[,]
        //             {
        //     {5, 3, 0, 0, 7, 0, 0, 0, 0},
        //     {6, 0, 0, 1, 9, 5, 0, 0, 0},
        //     {0, 9, 8, 0, 0, 0, 0, 6, 0},
        //     {8, 0, 0, 0, 6, 0, 0, 0, 3},
        //     {4, 0, 0, 8, 0, 3, 0, 0, 1},
        //     {7, 0, 0, 0, 2, 0, 0, 0, 6},
        //     {0, 6, 0, 0, 0, 0, 2, 8, 0},
        //     {0, 0, 0, 4, 1, 9, 0, 0, 5},
        //     {0, 0, 0, 0, 8, 0, 0, 7, 9}
        //             };

        public static string[] datasample = new string[] {
                "5 3 0 0 7 0 0 0 0",
                "6 0 0 1 9 5 0 0 0",
                "0 9 8 0 0 0 0 6 0",
                "8 0 0 0 6 0 0 0 3",
                "4 0 0 8 0 3 0 0 1",
                "7 0 0 0 2 0 0 0 6",
                "0 6 0 0 0 0 2 8 0",
                "0 0 0 4 1 9 0 0 5",
                "0 0 0 0 8 0 0 7 9",
            };
        public static void Main(string[] args)
        {
            bool hasInputFile = false;
            string inputFile = "";
            //Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(args));
            
            
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i] == "-i" && i + 1 < args.Length)
                    {
                        hasInputFile =true;
                        inputFile = args[i + 1];
                        break;
                    }
                }

                if (hasInputFile)
                {
                    Console.WriteLine("Input file: " + inputFile);
                }
                else
                {
                    Console.WriteLine("Error: Missing input file parameter (-i).");
                }
        


            // Sudoku sudoku1 = new Sudoku(Program.board);

            InputLoader inputLoader = new InputLoader();

            SudokuParser sudokuParser = new SudokuParser();

            SudokuPrinter sudokuPrinter = new SudokuPrinter();
            SudokuSolver sudokuSolver = new SudokuSolver();
            var data = inputLoader.Load("Sudoku.txt");
            var sudoku = sudokuParser.Parser(data);
            var result = sudokuSolver.Solve(sudoku);
            //  sudokuPrinter.Print(sudoku);
            sudokuPrinter.Print(result);

            // Bảng Sudoku được biểu diễn bằng một mảng 2D
            // 0 đại diện cho ô trống

            // if (SolveSudoku(board))
            // {
            //     // In bảng Sudoku đã giải
            //     PrintBoard(board);
            // }
            // else
            // {
            //     Console.WriteLine("Không có lời giải cho bài đố Sudoku này");
            // }
        }
    }

}

