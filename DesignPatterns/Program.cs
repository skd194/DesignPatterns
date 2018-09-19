using Microsoft.Office.Interop.Excel;
using System;

namespace DesignPatterns
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            //var currentPath = AppDomain.CurrentDomain.BaseDirectory;
            //var excel = new Excel($@"{currentPath}exceltrail2.xlsx", 2);
            Excel
                .InitializeExcel("a")
                .CreateNewWorkBook()
                .OpenWorkSheet(2)
                .ReadMatrix(new Cell(), new Cell());



            Excel.InitializeExcel("a")
                .OpenExistingWorkBook()
                .OpenWorkSheet(3)
                .WriteMatrix(new Cell(), new[,] { {"0", "2"}})
                .Save()
                .Close();



            //var a = excel.ReadCell(0, 0);
            //Console.WriteLine(a);

            //excel.WriteToCell(1,1, "4566445");
            //excel.Save();
            //excel.Close();


            //excel = new Excel();
            //excel.CreateNewFile();
            //excel.WriteToCell(1, 1, "100");
            //excel.SaveAs($@"{currentPath}exceltrail4.xlsx");
            //excel.Close();
        }
    }


    internal class Excel1
    {
        //private readonly _Worksheet _workSheet;
        //private _Workbook _workBook;
        //private readonly _Application _excel;

        //public Excel1()
        //{
        //    _excel = new Application();
        //}

        //public Excel1(string path, int sheet)
       // {
            //_excel = new Application();
            //_workBook = _excel.Workbooks.Open(path);
           // _workSheet = _workBook.Worksheets[sheet];
        //}

        //public string ReadCell(int row, int column)
        //{
        //    return new Cell(_workSheet, row, column)
        //        .Read();
        //}

        //public void WriteToCell(int row, int column, string content)
        //{
        //    new Cell(_workSheet, row, column)
        //        .Write(content);
        //}

        //public void Save() 
        //{
        //    _workBook.Save();
        //}

        //public void SaveAs(string path)
        //{
        //    _workBook.SaveAs(path);
        //}

        //public void Close()
        //{
        //    _workBook.Close();
        //}

        //public void CreateNewFile()
        //{
        //    _workBook = _excel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
        //}
    }



    public interface IInitializeWorkBook
    {
        IInitializeWorkSheet CreateNewWorkBook();
        IInitializeWorkSheet OpenExistingWorkBook();
    }

    public interface IInitializeWorkSheet
    {
        IReadWriteOperations OpenWorkSheet(int sheetNumber);
    }

    public interface IReadWriteOperations
    {
        string[,] ReadMatrix(Cell firstCell, Cell lastCell);
        ISave WriteMatrix(Cell startCell, string[,] content);
    }

    public interface ISave
    {
        IClose SaveAs(string newPath);
        IClose Save();
    }

    public interface IClose
    {
        void Close();
    }

    internal class Excel : IInitializeWorkBook, IInitializeWorkSheet,
        IReadWriteOperations, ISave, IClose
    {
        private _Worksheet _workSheet;
        private _Workbook _workBook;
        private readonly _Application _excel;
        private readonly string _path;

        private Excel(string path)
        {
            _path = path;
            _excel = new Application();
        }

        public static IInitializeWorkBook InitializeExcel(string path)
        {
            return new Excel(path);
        }

        public IInitializeWorkSheet CreateNewWorkBook()
        {
            _workBook = _excel.Workbooks.Add(
                XlWBATemplate.xlWBATWorksheet);
            return this;
        }

        public IInitializeWorkSheet OpenExistingWorkBook()
        {
            _workBook = _excel.Workbooks.Open(_path);
            return this;
        }

        public IReadWriteOperations OpenWorkSheet(int sheetNumber)
        {
            _workSheet = _workBook.Worksheets[sheetNumber];
            return this;
        }

        public string[,] ReadMatrix(Cell firstCell, Cell lastCell)
        {

            //implement this
            var b = new ExcelCell(_workSheet, firstCell);
            var a =  new string[0, 0];
            _workBook.Close();
            return a;
        }

        public ISave WriteMatrix(Cell startCell, string[,] content)
        {

            //implement this
            throw new NotImplementedException();
        }

        public IClose SaveAs(string newPath)
        {
           _workBook.SaveAs(newPath);
            return this;
        }

        public IClose Save()
        {
            _workBook.Save();
            return this;
        }

        public void Close()
        {
            _workBook.Close();
        }
    }


    public class Cell
    {
        private int _row;

        private int _column;

        public int Row
        {
            get => _row + 1;
            set => _row = value;
        }

        public int Column
        {
            get => _column + 1;
            set => _column = value;
        }
    }


    public class ExcelCell
    {
        private readonly _Worksheet _workSheet;

        private readonly Cell _cell;

        public ExcelCell(_Worksheet workSheet,  Cell cell)
        {
            _workSheet = workSheet;
            _cell = cell;
        }

        public void Write(string content)
        {
            _workSheet.Cells[_cell.Row, _cell.Column].Value2 = content;
        }

        public string Read()
        {
            return _workSheet.Cells[_cell.Row, _cell.Column].Value2
                   ?? string.Empty;
        }
    }
}




