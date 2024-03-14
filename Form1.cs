using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LinealEquasions.StaticValues;

namespace LinealEquasions
{
    public partial class Form1 : Form
    {
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
        //To do: Понять как получить доступ к колонке со всеми её значениями
        private void GaussJordan_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < ArgumentsTable.RowCount; i++)
            {
                int MaxElementIndex = FindIndexOfBiggestColumnElement(ArgumentsTable.Columns[i],i);
                MessageBox.Show(ArgumentsTable[i,MaxElementIndex].ToString());
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
            double MaxValue = double.Parse(table[ColumnIndex, OffSet].Value.ToString());
            for (int i = OffSet; i < table.RowCount; i++)
            {
                double CurrentValue = double.Parse(table[ColumnIndex, i].Value.ToString());
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
        /// <summary>
        /// Получает размер таблицы для уравнений из TextBox, если таковые не указаны, то берёт их из файла со статическими значениями
        /// </summary>
        /// <returns>RowCount,ColumnsCount</returns>
    }
}
