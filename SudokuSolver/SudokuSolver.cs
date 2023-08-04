namespace SudokuSolver
{
    public class SudokuSolver
    {

      
        static bool IsSafe(int[,] board, int row, int col, int num)
        {
            // Kiểm tra xem số num có hợp lệ để điền vào vị trí (row, col) hay không

            // Kiểm tra hàng
            for (int i = 0; i < 9; i++)
            {
                if (board[row, i] == num)
                    return false;
            }

            // Kiểm tra cột
            for (int i = 0; i < 9; i++)
            {
                if (board[i, col] == num)
                    return false;
            }

            // Kiểm tra vùng 3x3
            int startRow = 3 * (row / 3);
            int startCol = 3 * (col / 3);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[startRow + i, startCol + j] == num)
                        return false;
                }
            }

            return true;
        }
        bool SolveSudoku(int[,] board)
        {
            int row = -1;
            int col = -1;
            bool isEmpty = true;

            // Tìm ô trống (có giá trị 0) trong bảng Sudoku
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i, j] == 0)
                    {
                        row = i;
                        col = j;
                        isEmpty = false;
                        break;
                    }
                }
                if (!isEmpty)
                    break;
            }

            // Nếu không còn ô trống, bảng đã được điền đầy đủ và đã giải xong
            if (isEmpty)
                return true;

            // Thử điền các số từ 1 đến 9 vào ô trống
            for (int num = 1; num <= 9; num++)
            {
                if (IsSafe(board, row, col, num))
                {
                    board[row, col] = num;

                    // Đệ quy giải quyết bài đố cho ô tiếp theo
                    if (SolveSudoku(board))
                        return true;

                    // Nếu không tìm được lời giải với số này, đặt lại ô thành trống và thử số khác
                    board[row, col] = 0;


                }

            }
            // copyArray = (int[,])board.Clone();
            return false; // Nếu không có số nào hợp lệ, quay lại bước trước
        }
        internal Sudoku Solve(Sudoku sudoku)
        {
            var r = new Sudoku(sudoku.Board.Clone() as int[,]);
            SolveSudoku(r.Board);
            return r;
        }
    }
}