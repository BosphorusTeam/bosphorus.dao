using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;
using Bosphorus.Common.Clr.IO.TextWriter;
using Bosphorus.Dao.Client.Model;

namespace Bosphorus.Dao.Client
{
    public partial class ClientForm : Form
    {
        public ClientForm(IExecutionItemList executionItemList)
        {
            InitializeComponent();

            lbQueries.Items.Clear();
            IExecutionItem[] orderedItems = executionItemList.List.OrderBy(item => item.ToString()).ToArray();
            lbQueries.Items.AddRange(orderedItems);

            TextWriter textWriter = new RichTextBoxWriter(tbConsole);
            TextWriter compsoiteWriter = new CompositeTextWriter(Console.Out, textWriter);
            Console.SetOut(compsoiteWriter);
        }

        private void lbQueries_DoubleClick(object sender, EventArgs e)
        {
            FireQueryModel();
        }

        private void FireQueryModel()
        {
            if (lbQueries.SelectedIndex == -1)
                return;

            Cursor current = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            tbConsole.Clear();
            tbConsole.Refresh();
            Console.Clear();
            IExecutionItem executionItem = (IExecutionItem)lbQueries.SelectedItem;

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            IList data = executionItem.Execute();
            stopWatch.Stop();

            dgResult.Text = executionItem.ToString();
            dgResult.DataSource = data;
            dgResult.CellFormatting += DgResultOnCellFormatting;

            int count = data.Count;
            double totalSeconds = stopWatch.Elapsed.TotalSeconds;
            int countPerSecond = (int)(count / totalSeconds);
            this.Text = string.Format("Count: {0}, Time: {1}, CountPerSecond: {2}", count, totalSeconds, countPerSecond);

            Cursor.Current = current;
        }

        private void DgResultOnCellFormatting(object sender, DataGridViewCellFormattingEventArgs dataGridViewCellFormattingEventArgs)
        {
            int columnIndex = dataGridViewCellFormattingEventArgs.ColumnIndex;
            DataGridView grid = (DataGridView)sender;
            DataGridViewColumn column = grid.Columns[columnIndex];
            Type columnValueType = column.ValueType;
            if (columnValueType == typeof(string))
                return;

            if (columnValueType.IsValueType)
                return;

            dataGridViewCellFormattingEventArgs.Value = "[??]";
        }

        private void lbQueries_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                FireQueryModel();
        }
    }
}