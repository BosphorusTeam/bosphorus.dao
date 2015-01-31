using System;
using System.Collections.Generic;
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
        public ClientForm(IList<IExecutionItemList> executionItemListList)
        {
            InitializeComponent();

            IEnumerable<TreeNode> treeNodes = from executionItemList in executionItemListList
                            orderby executionItemList.ToString()
                            select BuildTreeNode(executionItemList);
                            

            tvExecutionList.Nodes.AddRange(treeNodes.ToArray());


            TextWriter textWriter = new RichTextBoxWriter(tbConsole);
            TextWriter compsoiteWriter = new CompositeTextWriter(Console.Out, textWriter);
            Console.SetOut(compsoiteWriter);
        }

        private TreeNode BuildTreeNode(IExecutionItemList executionItemList)
        {
            IEnumerable<TreeNode> treeNodes = from executionItem in executionItemList.List
                            select BuildTreeNode(executionItem);

            TreeNode node = new TreeNode(executionItemList.ToString(), treeNodes.ToArray());
            return node;
        }

        private TreeNode BuildTreeNode(IExecutionItem executionItem)
        {
            TreeNode node = new TreeNode(executionItem.ToString());
            node.Tag = executionItem;
            return node;
        }

        private void FireQueryModel(IExecutionItem executionItem)
        {
            if (executionItem == null)
                return;

            Cursor current = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            tbConsole.Clear();
            tbConsole.Refresh();
            Console.Clear();

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

        private void tvExecutionList_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode treeNode = e.Node;
            IExecutionItem executionItem = (IExecutionItem) treeNode.Tag;
            FireQueryModel(executionItem);
        }
    }
}