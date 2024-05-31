using System;
using System.Windows.Forms;
using static LinealEquasions.StaticValues;
using MathNet.Numerics.LinearAlgebra;


namespace LinealEquasions
{
    public partial class Form1 : Form
    {
        int Offset = 0;
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Генерирует в <see cref="ArgumentsTable"/> таблицу размером указанным пользователем +1 строка и колонка (для Значений уравнений и найденных корней)
        /// <para>Значения для определения размера берет из <see cref="TableSize"/> и <see cref="Columns"/>, если таковые не указаны то берёт значения из <see cref="StaticValues"/></para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateTable_Click(object sender, EventArgs e)
        {
            int Size = GetTableSize();
            ArgumentsTable.RowCount = Size;
            ArgumentsTable.ColumnCount = Size+TableColumnsOffSet;
            for (int i = 0; i <= Size; i++)
            {
                ArgumentsTable.Columns[i].HeaderCell.Value = "X" + (i+1).ToString();
            }
            ArgumentsTable.Columns[Size].HeaderCell.Value = "B";
            ArgumentsTable.Columns[Size +1].HeaderCell.Value = "Корни";
        }
        /// <summary>
        /// Заполняет случайными значениями множители аргументов X, а также значения уравнений B.<para>
        /// Диапазон значений берёт от пользователя, либо из файла с значениями по умолчанию <see cref="StaticValues"/></para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FillEmptyFields_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            (int MinValue, int MaxValue) = GetMinMaxValue();
            for (int i = 0; i < ArgumentsTable.ColumnCount - 1; i++)
            {
                for (int j = 0; j < ArgumentsTable.RowCount; j++)
                {
                    if (ArgumentsTable[i,j].Value== null)
                    {
                        ArgumentsTable[i, j].Value = rnd.Next(MinValue, MaxValue).ToString();
                    }
                }
            }
        }
        /// <summary>
        /// Получает пределы значений из TextBox, если таковоые не указаны, то берёт их из файла со статическими значениями
        /// </summary>
        /// <returns><see cref="int"/> Размер для квадратной матрицы</returns>
        private int GetTableSize()
        {
            int Size = !String.IsNullOrEmpty(TableSize.Text) && Int32.TryParse(TableSize.Text, out Size) ? Size : DefaultTableSize;
            return Size;
        }
        private void GaussJordan_Click(object sender, EventArgs e)
        {
            Reverse(ref ArgumentsTable);
        }
        private void Reverse(ref DataGridView table)
        {
            double[] mult = new double[ArgumentsTable.RowCount];
            for (int i = 0; i < mult.Length; i++)
            {
                mult[i] = 0;
            }
            for (int i = 0; i < table.RowCount; i++)
            {
                double total = 0;
                for (int j = 0; j < table.ColumnCount-2; j++)
                {
                    total += Convert.ToDouble(table[j, table.RowCount-1-i].Value) * mult[j];
                }
                
                mult[mult.Length-i-1] =
                 (Convert.ToDouble(table[table.ColumnCount - 1-1, table.RowCount - i-1].Value)-total) /
                 Convert.ToDouble(table[table.ColumnCount - 2 - i - 1, table.RowCount - i - 1].Value);
                table[table.ColumnCount-1, table.RowCount - i-1].Value = mult[mult.Length-i-1];
            }
        }

        /// <summary>
        /// Меняет местами строки в таблице <paramref name="table"/> <seealso cref="DataGridView"/>
        /// </summary>
        /// <param name="table">GataGridView в котором будут меняться строки</param>
        /// <param name="point1">Номер первой строки</param>
        /// <param name="point2">Номер второй строки</param>
        private void SwapRows(ref DataGridView table, int point1,int point2)
        {
            if (point1==point2)
            {
                return;
            }
            if (point1< point2)
            {
                (point1, point2) = (point2, point1);
            }
            var Row1 = table.Rows[point1];
            var Row2 = table.Rows[point2];
            table.Rows.Remove(Row2);
            table.Rows.Remove(Row1);
            table.Rows.Insert(point2, Row1);
            table.Rows.Insert(point1, Row2);
        }
        private int FindIndexOfBiggestColumnElement(DataGridViewColumn col,int OffSet)
        {
            DataGridView table = col.DataGridView;
            int ColumnIndex = col.Index;
            int RowIndex = OffSet;
            double MaxValue = Math.Abs(double.Parse(table[ColumnIndex, OffSet].Value.ToString()));
            for (int i = OffSet; i < table.RowCount; i++)
            {
                double CurrentValue = Math.Abs(double.Parse(table[ColumnIndex, i].Value.ToString()));
                if (CurrentValue>MaxValue)
                {
                    MaxValue = CurrentValue;
                    RowIndex = i;
                }
            }
            return RowIndex;
        }
        private Tuple<int, int> GetMinMaxValue()
        {
            int MinValue = !String.IsNullOrEmpty(LowerValueLimit.Text) && Int32.TryParse(LowerValueLimit.Text, out MinValue) ? MinValue : DefaultMinRandomValue;
            int MaxValue = !String.IsNullOrEmpty(UpperValueLimit.Text) && Int32.TryParse(UpperValueLimit.Text, out MaxValue) ? MaxValue : DefaultMaxRandomValue;
            return new Tuple<int, int>(MinValue,MaxValue);
        }

        private void LeadElementBtn_Click(object sender, EventArgs e)
        {
            int index = FindIndexOfBiggestColumnElement(ArgumentsTable.Columns[Offset], Offset);
            SwapRows(ref ArgumentsTable, Offset, index);
        }

        private void StepBtn_Click(object sender, EventArgs e)
        {
            Factorize(ref ArgumentsTable, Offset);
            Offset++;
            if (Offset==ArgumentsTable.RowCount-1)
            {
                GaussJordan.IsAccessible = false;
            }
        }

        private void Factorize(ref DataGridView table,int Offset)
        {
            for (int i = Offset+1; i < table.RowCount; i++)
            {
                double mul = -Convert.ToDouble(table[Offset, i].Value) / Convert.ToDouble(table[Offset, Offset].Value) ;
                for (int j = Offset; j < table.ColumnCount-1; j++)
                {
                    table[j, i].Value = Convert.ToDouble(table[j, Offset].Value) * mul  + Convert.ToDouble(table[j,i].Value);
                }
            }
        }

        private void Gauss_ZeidelBtn_Click(object sender, EventArgs e)
        {
            // Размер матрицы (предположим, квадратная матрица)
            int n = ArgumentsTable.RowCount;

            // Извлечение матрицы коэффициентов и столбца значений
            double[,] A = new double[n, n];
            double[] b = new double[n];
            double[] x = new double[n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    A[i, j] = Convert.ToDouble(ArgumentsTable.Rows[i].Cells[j].Value);
                }
                b[i] = Convert.ToDouble(ArgumentsTable.Rows[i].Cells[n].Value);
                x[i] = Convert.ToDouble(ArgumentsTable.Rows[i].Cells[n + 1].Value); // Начальное предположение корней
            }

            // Параметры метода Гаусса-Зейделя
            double tolerance = 1e-10;
            int maxIterations = 1000;

            // Выполнение метода Гаусса-Зейделя
            bool converged = GaussSeidel(A, b, x, tolerance, maxIterations);

            // Обновление столбца корней в DataGridView
            if (converged)
            {
                for (int i = 0; i < n; i++)
                {
                    ArgumentsTable.Rows[i].Cells[n + 1].Value = x[i];
                }
                MessageBox.Show("Система решена успешно.");
            }
            else
            {
                MessageBox.Show("Метод не сошелся.");
            }
        }

        private bool GaussSeidel(double[,] A, double[] b, double[] x, double tolerance, int maxIterations)
        {
            int n = b.Length;
            double[] xNew = new double[n];
            Array.Copy(x, xNew, n);

            for (int iteration = 0; iteration < maxIterations; iteration++)
            {
                for (int i = 0; i < n; i++)
                {
                    double sum = 0.0;
                    for (int j = 0; j < n; j++)
                    {
                        if (j != i)
                        {
                            sum += A[i, j] * xNew[j];
                        }
                    }
                    xNew[i] = (b[i] - sum) / A[i, i];
                }

                // Проверка на сходимость
                double maxDiff = 0.0;
                for (int i = 0; i < n; i++)
                {
                    maxDiff = Math.Max(maxDiff, Math.Abs(xNew[i] - x[i]));
                }
                if (maxDiff < tolerance)
                {
                    Array.Copy(xNew, x, n);
                    return true; // Сошелся
                }

                Array.Copy(xNew, x, n);
            }

            return false; // Не сошелся
        }

    }
}
