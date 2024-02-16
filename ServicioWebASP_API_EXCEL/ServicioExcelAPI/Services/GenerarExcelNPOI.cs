using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.Streaming;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace ServicioAPI.Services
{
    public class GenerarExcelNPOI
    {
        public enum TipoFormato { XLS, XLSX }

        public string GetMimeType(TipoFormato formato)
        {
            if (formato == TipoFormato.XLS)
            {
                return "application/vnd.ms-excel";
            }
            else
            {
                return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            }
        }

        public byte[] GenerarExcel(DataTable tabla, TipoFormato formato = TipoFormato.XLSX)
        {

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");

            int nroLinea = 0;
            int nroColumna = 0;

            #region formato
            IWorkbook wb = null;
            if (formato == TipoFormato.XLS)
            {
                wb = new HSSFWorkbook();
            }
            else
            {
                wb = new SXSSFWorkbook();
            }
            #endregion

            var sheet = wb.CreateSheet("Hoja1");

            #region fuente Set font style
            IFont hFont = wb.CreateFont();
            hFont.FontName = "Arial";
            hFont.IsBold = true;
            hFont.FontHeightInPoints = 10;

            IFont font = wb.CreateFont();
            font.FontName = "Arial";
            font.FontHeightInPoints = 10;
            #endregion

            #region styles                       
            ICellStyle styleHText = wb.CreateCellStyle();
            styleHText.DataFormat = wb.CreateDataFormat().GetFormat("text");
            styleHText.WrapText = true;
            styleHText.SetFont(hFont);

            ICellStyle styleText = wb.CreateCellStyle();
            styleHText.DataFormat = wb.CreateDataFormat().GetFormat("text");
            styleHText.WrapText = true;
            styleHText.SetFont(font);
            #endregion


            foreach (DataColumn dr in tabla.Columns)
            {

            }

            foreach (DataRow dr in tabla.Rows)
            {
                nroColumna = 0;
                var row = sheet.CreateRow(++nroLinea);

                foreach (object cell in dr.ItemArray)
                {
                    string texto = Convert.ToString(cell);

                    #region texto
                    row.CreateCell(nroColumna);
                    row.GetCell(nroColumna).SetCellType(CellType.String);
                    if (string.IsNullOrEmpty(texto) == false)
                        row.GetCell(nroColumna).SetCellValue(texto);
                    row.GetCell(nroColumna).CellStyle = styleHText;
                    nroColumna++;
                    #endregion
                }
            }

            byte[] bytes = new byte[0];
            using (var ms = new MemoryStream())
            {
                wb.Write(ms);
                bytes = ms.ToArray();
            }

            GC.Collect();
            return bytes;
        }
    }
}